using System;
using System.Web.Http;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataServices.UserProfileServices;
using Epam.Wunderlist.MvcPL.Convertor;
using Epam.Wunderlist.MvcPL.Identity;

namespace Epam.Wunderlist.MvcPL.Controllers
{
    public class UserProfileController : ApiController
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController()
        {
            _userProfileService = (IUserProfileService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserProfileService));
        }

        [HttpGet]
        public object Get()
        {
            var userProfile = _userProfileService.GetById(User.Identity.GetUserId<int>());
            return new {
                UserName = userProfile.UserName,
                Email = userProfile.Email,
                Avatar = Convert.ToBase64String(userProfile.Avatar)
            };
        }

        [HttpGet]
        public object Get(int id)
        {
            var userProfile = _userProfileService.GetById(id);
            return userProfile;
        }

        [HttpPut]
        public void Put([FromBody]UserProfile userProfile)
        {
            _userProfileService.Update(userProfile);
        }
    }
}
