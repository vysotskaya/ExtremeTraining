using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "The field can not be empty.")] ///////////
        //[StringLength(30, ErrorMessage = "The email must contain 3-30 characters.", MinimumLength = 3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password.")]/////
        //[StringLength(100, ErrorMessage = "The password must contain at least 8 characters.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}