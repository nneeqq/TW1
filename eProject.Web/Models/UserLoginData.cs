using System.ComponentModel.DataAnnotations;

namespace eProject.Web.Models
{
    public class UserLoginData
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Username cannot be longer than 30 characters.")]
        public string Credential { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password cannot be shorter than 8 characters.")]
        public string Password { get; set; }
    }
}