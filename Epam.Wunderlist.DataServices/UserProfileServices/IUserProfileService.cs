using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataServices.UserProfileServices
{
    public interface IUserProfileService
    {
        IEnumerable<UserProfile> GetAll();
        UserProfile GetById(int id);
        void Create(UserProfile entity);
        void Update(UserProfile entity);
        void Delete(UserProfile entity);
    }
}
