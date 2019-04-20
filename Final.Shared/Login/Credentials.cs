using System.ComponentModel.DataAnnotations;

namespace Final.Shared
{
        public class Credentials
        {
            [DataType(DataType.EmailAddress)]
            [Required(ErrorMessage = "Email is required")]
            public string Email;

            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Password is required")]
            public string Password;
        }
}