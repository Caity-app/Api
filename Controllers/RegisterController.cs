using Api.Data;
using Api.Mappers;
using Api.Models.DataTransferObjects;
using Api.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterController : Controller
{
    private readonly CaityContext _context;

    public RegisterController(CaityContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDTO userDetails)
    {
        if (!userDetails.Email.IsValidEmail() || !userDetails.Password.IsValidPassword() ||
            string.IsNullOrEmpty(userDetails.Name))
        {
            return BadRequest();
        }

        var member = userDetails.MapToMember();
        _context.Members.Add(member);
        await _context.SaveChangesAsync();

        return Ok();

    }
}