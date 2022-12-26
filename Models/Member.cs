#nullable disable
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [InverseProperty("Members")]
        public List<House> Houses { get; set; }
        [InverseProperty("CreatedBy")]
        public List<House> CreatedHouses { get; set; }
    }
}
