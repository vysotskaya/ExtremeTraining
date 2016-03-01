using System;
using System.Web.Mvc;
using Epam.Wunderlist.DataServices.UserProfileServices;

namespace Epam.Wunderlist.MvcPL.Controllers
{
    public class ValidateController : Controller
    {
        private readonly IUserProfileService _userProfileService;

        public ValidateController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public JsonResult IsPasswordsMatch(string confirmPassword, string password)
        {
            return Json(String.CompareOrdinal(confirmPassword, password) == 0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsUserEmailExist(string email)
        {
            var userExist = _userProfileService.GetByEmail(email) == null;
            if (String.CompareOrdinal(User.Identity.Name, email) == 0)
            {
                userExist = false;
            }
            return Json(!userExist, JsonRequestBehavior.AllowGet);
        }
    }
}