using Api.Models.DataTransferObjects;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class RegisterController : Controller
{
    private readonly MemberRegistration _memberRegistration;

    public RegisterController(MemberRegistration memberRegistration)
    {
        _memberRegistration = memberRegistration;
    }

    [HttpPost("api/register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO userDetails)
    {
        var member = await _memberRegistration.RegisterMember(userDetails);

        if (member == null)
        {
            return BadRequest();
        }

        return Ok();

    }
}