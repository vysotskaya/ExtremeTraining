using DAL.Interface.DalEntities;
using ORM;

namespace DAL.Mappers
{
    public static partial class DalOrmMapper
    {
        public static DalUser ToDalUser(this User user)
        {
            return new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Photo = user.Photo
            };
        }

        public static User ToUser(this DalUser dalUser)
        {
            return new User()
            {
                Id = dalUser.Id,
                Email = dalUser.Email,
                Name = dalUser.Name,
                Password = dalUser.Password,
                Photo = dalUser.Photo
            };
        }
    }
}
