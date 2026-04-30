using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.AuthModels
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        public string Firstname { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        public string Lastname { get; set; }
    }
}
