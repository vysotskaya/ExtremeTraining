using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Epam.Wunderlist.MvcPL.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "The field can not be empty.")]///////
        [StringLength(200, ErrorMessage = "The name must contain no more 200 characters.")]/////////
        public string Name { get; set; }

        [Required(ErrorMessage = "The field can not be empty.")]///////
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email.")]//////
        [StringLength(200, ErrorMessage = "The email must contain no more 200 characters.")]/////////
        [Remote("IsUserEmailExist", "Validate", ErrorMessage = "This email has already existed.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password.")]
        [StringLength(100, ErrorMessage = "The password must contain at least 8 characters.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public HttpPostedFileBase Photo { get; set; }
    }
}