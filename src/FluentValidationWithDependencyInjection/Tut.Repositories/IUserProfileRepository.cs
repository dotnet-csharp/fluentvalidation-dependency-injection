using Tut.Entities;

namespace Tut.Repositories
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        void DeleteUserProfile(int userId);
        UserProfile GetUserprofileById(int userId);
        UserProfile GetUserProfileByUserName(string userName);
    }
}