using Tut.Entities;

namespace Tut.Services
{
    public interface IUserProfileServices : IEntityServices<UserProfile>
    {
        UserProfile GetByUserName(string userName);
        UserProfile GetByUserId(int userId);
    }
}