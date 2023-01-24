using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Data;
using Api.Utils;
using Api.Validators;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services
{
    public class MemberAuthentication
    {
        private readonly CaityContext _context;
        private readonly IConfiguration _configuration;

        public MemberAuthentication(CaityContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public JwtSecurityToken? AuthenticateUser(string email, string password)
        {
            if (!email.IsValidEmail() || !password.IsValidPassword())
            {
                return null;
            }

            var member = _context.Members.FirstOrDefault(x => x.Email == email.ToLower() && x.Password == PasswordHelper.GetHashedVariant(password));
            if (member == null)
            {
                return null;
            }

            // create JWT
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", member.Id.ToString()),
                new Claim("name", member.Name),
                new Claim("email", member.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"], 
                _configuration["Jwt:Audience"], 
                claims,
                expires: DateTime.Now.AddHours(24), 
                signingCredentials: credentials
            );

            return token;
        }
    }
}