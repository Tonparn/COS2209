using System.ComponentModel.DataAnnotations;

namespace Final.Shared
{
    public class UserParam
    {
        [Required]
        [StringLength(10, ErrorMessage = "Name is to long")]
        public string Name;

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string Email;

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Password confirm do not match.")]
        public string Password2 { get; set; }
    }
}
