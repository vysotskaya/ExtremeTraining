using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
                {
                    //FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RememberMe);
                    FormsAuthentication.SetAuthCookie(viewModel.Email, true);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect login or password.");
            }
            return View(viewModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegisterViewModel viewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    var userWithSameEmail = _userService.GetUserByEmail(viewModel.Email) == null;

            //    if (!userWithSameEmail)
            //    {
            //        ModelState.AddModelError("", "User with this email already exist.");
            //        return View(viewModel);
            //    }

            //    var membershipUser = ((CustomMembershipProvider) Membership.Provider);
            //        //.CreateUser(viewModel);

            //    if (membershipUser != null)
            //    {
            //        FormsAuthentication.SetAuthCookie(viewModel.Email, false);
            //        return RedirectToAction("Index", "Home");
            //    }
            //    ModelState.AddModelError("", "Error registration.");
            //}
            return View(viewModel);
        }

        [ChildActionOnly]
        public ActionResult LoginPartial()
        {
            return PartialView("_LoginPartial");
        }
    }
}