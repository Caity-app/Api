using Api.Data;
using Api.Mappers;
using Api.Models;
using Api.Models.DataTransferObjects;
using Api.Validators;

namespace Api.Services
{
    public class MemberRegistration
    {
        private readonly CaityContext _context;

        public MemberRegistration(CaityContext context)
        {
            _context = context;
        }

        public async Task<Member> RegisterMember(RegisterDTO userDetails)
        {
            if (!userDetails.Email.IsValidEmail() || !userDetails.Password.IsValidEmail() ||
                string.IsNullOrEmpty(userDetails.Name))
            {
                return null;
            }

            var member = userDetails.MapToMember();
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return member;
        }
    }
}