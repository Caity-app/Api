using Api.Models;
using Api.Models.DataTransferObjects;
using Api.Utils;

namespace Api.Mappers;

public static class MemberMapper
{
    public static Member MapToMember(this RegisterDTO registerDto)
    {
        var member = new Member
        {
            Name = registerDto.Name,
            CreatedDate = DateTime.UtcNow,
            Email = registerDto.Email.ToLower(),
            Password = PasswordHelper.GetHashedVariant(registerDto.Password),
            Id = new Guid()
        };

        if (registerDto.House != null)
        {
            member.Houses = new List<House> { registerDto.House };
        }
        
        return member;
    }
}