using Api.Data;
using Api.Models;
using Api.Models.DataTransferObjects;
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
        public LoginController(CaityContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO userDetails)
        {
            if (!userDetails.Email.IsValidEmail() || !userDetails.Password.IsValidPassword())
            {
                return Unauthorized();
            }

            var member = _context.Members.FirstOrDefault(x => x.Email == userDetails.Email.ToLower() && x.Password == userDetails.Password);
            if (member == null)
            {
                return Unauthorized();
            }

            //TODO create JWT for authorization 

            return Ok();
        }
    }
}
