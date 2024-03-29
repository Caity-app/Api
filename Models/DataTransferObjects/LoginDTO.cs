﻿using System.ComponentModel.DataAnnotations;

namespace Api.Models.DataTransferObjects
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
    }
}
