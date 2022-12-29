using Api.Data;
using Api.Models.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Api.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MemberAuthentication _userAuthentication;

        public LoginController(MemberAuthentication userAuthentication)
        {
            _userAuthentication = userAuthentication;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO userDetails)
        {
            var token = _userAuthentication.AuthenticateUser(userDetails.Email, userDetails.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
