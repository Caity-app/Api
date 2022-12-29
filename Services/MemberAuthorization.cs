using Api.Data;
using Api.Models;

namespace Api.Services
{
    public class MemberAuthorization
    {
        private readonly CaityContext _context;

        public MemberAuthorization(CaityContext context)
        {
            _context = context;
        }

        public bool IsMemberAuthorized(Member member)
        {
            throw new NotImplementedException();
        }
    }
}