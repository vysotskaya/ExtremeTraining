using System.Collections.Generic;
using BLL.Interface.BllEntities;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        IEnumerable<UserEntity> GetAllUserEntities();
        UserEntity GetUserEntity(int id);
        void CreateUser(UserEntity user);
        void UpdateUser(UserEntity user);
        void DeleteUser(UserEntity user);
        UserEntity GetUserByEmail(string email);
    }
}
