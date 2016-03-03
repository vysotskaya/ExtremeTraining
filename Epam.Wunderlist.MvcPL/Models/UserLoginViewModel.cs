using System.ComponentModel.DataAnnotations;

namespace Epam.Wunderlist.MvcPL.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "The field can not be empty.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}