using System;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Services;

namespace MvcPL.Controllers
{
    public class ValidateController : Controller
    {
        private readonly IUserService _userService;

        public ValidateController(IUserService userService)
        {
            _userService = userService;
        }

        public JsonResult IsPasswordsMatch(string confirmPassword, string password)
        {
            return Json(String.CompareOrdinal(confirmPassword, password) == 0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsUserEmailExist(string email)
        {
            var userExist = _userService.GetUserByEmail(email) == null;
            if (String.CompareOrdinal(User.Identity.Name, email) == 0)
            {
                userExist = false;
            }
            return Json(!userExist, JsonRequestBehavior.AllowGet);
        }
    }
}