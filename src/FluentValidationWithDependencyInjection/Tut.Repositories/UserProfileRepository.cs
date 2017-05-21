using System.Data.Entity;
using System.Linq;
using Tut.Entities;

namespace Tut.Repositories
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DIContext context) : base(context)
        {
        }

        public void DeleteUserProfile(int userId)
        {
            using (var context = new DIContext())
            {
                var user = context.UserProfiles.Find(userId);
                context.UserProfiles.Attach(user);
                context.Entry(user).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public UserProfile GetUserprofileById(int userId)
        {
            return Find(x => userId);
        }

        public UserProfile GetUserProfileByUserName(string userName)
        {
            return FindBy(x => x.UserName == userName).FirstOrDefault();
        }
    }
}