using Api.Models.DataTransferObjects;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterController : Controller
{
    private readonly MemberRegistration _memberRegistration;

    public RegisterController(MemberRegistration memberRegistration)
    {
        _memberRegistration = memberRegistration;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDTO userDetails)
    {
        var member = await _memberRegistration.RegisterMember(userDetails);

        if (member == null)
        {
            return BadRequest();
        }

        return Ok();

    }
}