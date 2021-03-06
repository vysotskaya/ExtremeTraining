﻿using System;
using System.Drawing;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataServices.UserProfileServices;
using Epam.Wunderlist.Logger;
using Epam.Wunderlist.MvcPL.Convertor;
using Epam.Wunderlist.MvcPL.Identity;
using Epam.Wunderlist.MvcPL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Epam.Wunderlist.MvcPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        public IdentityUserProfileManager UserProfileManager { get; private set; }

        public AccountController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
            UserProfileManager = new IdentityUserProfileManager();
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
        public async Task<ActionResult> Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var defaultAvatar = Image.FromFile(Server.MapPath("~/Content/images/photo.png"));
                var user = new UserProfile()
                {
                    Email = model.Email,
                    Password = Crypto.HashPassword(model.Password),
                    UserName = model.Name,
                    Avatar = defaultAvatar.ImageToByteArray()
                };
                var result = await UserProfileManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("wunderlist", "Wunderlist");
                }
                ModelState.AddModelError("", result.Errors.ToString());
            }
            return View(model);
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
        public async Task<ActionResult> Login(UserLoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserProfileManager.FindAsync(model.Email, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, true);
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("", "Invalid email or password.");
            }
            return View(model);
        }

        [Authorize]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        private async Task SignInAsync(UserProfile user, bool isPersistent)
        {
            try
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var identity = await UserProfileManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
            }
            catch (Exception e)
            {
                Log.LogError(e);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task Edit(UserProfileEditViewModel userProfile)
        {
            var existedUserProfile = _userProfileService.GetByEmail(User.Identity.GetUserEmail());
            if (existedUserProfile != null)
            {
                try
                {
                    Image avatar = ResizeImage(userProfile.Avatar);
                    existedUserProfile.UserName = userProfile.UserName;
                    existedUserProfile.Avatar = avatar.ImageToByteArray();
                    _userProfileService.Update(existedUserProfile);
                    User.UpdateClaim(ClaimsIdentity.DefaultNameClaimType, userProfile.UserName, ClaimValueTypes.String);
                    var identity = User.Identity as ClaimsIdentity;
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
                }
                catch (Exception e)
                {
                    Log.LogError(e);
                }
            }
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");

        }

        private Image ResizeImage(HttpPostedFileBase avatar)
        {
            Image image = Image.FromStream(avatar.InputStream);
            return image?.GetThumbnailImage(128, (128 * image.Height) / image.Width, null, IntPtr.Zero);
        }
    }
}