using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eProject.Web.Models
{
    public class UserRegisterData
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Username cannot be longer than 30 characters.")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password cannot be shorter than 8 characters.")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Repeat Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password need to be the same as first entry.")]
        public string RepeatPassword { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(30)]
        public string Email { get; set; }
    }
}