using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repositories
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        UserProfile GetUserProfileByEmail(string email);
    }
}
