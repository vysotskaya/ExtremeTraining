using System;
using System.Web;

namespace Epam.Wunderlist.MvcPL.Models
{
    public class UserProfileEditViewModel
    {
        public HttpPostedFileBase Avatar { get; set; }
        public String UserName { get; set; }
    }
}