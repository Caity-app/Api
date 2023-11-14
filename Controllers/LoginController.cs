using Api.Data;
using Api.Models;
using Api.Models.DataTransferObjects;
using Api.Services;
using Api.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Validators;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly CaityContext _context;
        private readonly AuthService _authService;

        public LoginController(CaityContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO userDetails)
        {
            if (!userDetails.Email.IsValidEmail() || !userDetails.Password.IsValidPassword())
            {
                return Unauthorized();
            }

            var member = _context.Members.ToList().FirstOrDefault(x =>
                string.Equals(x.Email, userDetails.Email, StringComparison.CurrentCultureIgnoreCase) &&
                x.Password == PasswordHelper.GetHashedVariant(userDetails.Password));
            if (member == null)
            {
                return Unauthorized();
            }

            var token = _authService.GenerateJwtToken(member.Id.ToString());

            return Ok(token);
        }
    }
}
