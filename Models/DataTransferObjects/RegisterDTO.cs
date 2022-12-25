using System.ComponentModel.DataAnnotations;

namespace Api.Models.DataTransferObjects
{
    public class RegisterDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public House? House { get; set; }
    }
}
