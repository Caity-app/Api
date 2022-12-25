#nullable disable
namespace Api.Models
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<House> Houses { get; set; }
    }
}
