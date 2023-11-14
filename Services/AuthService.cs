using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services;

public class AuthService
{
    public string GenerateJwtToken(string userId)
    {
        var certificate = new X509Certificate2("C:/Certs/private-key.pfx", "dev1");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new (ClaimTypes.Name, userId)
            }),
            Expires = DateTime.UtcNow.AddDays(15),
            SigningCredentials = new X509SigningCredentials(certificate)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}