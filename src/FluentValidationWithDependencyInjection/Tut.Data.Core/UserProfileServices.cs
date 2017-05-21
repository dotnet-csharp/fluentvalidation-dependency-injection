using Tut.Entities;
using Tut.Repositories;

namespace Tut.Services
{
    public class UserProfileServices : EntityServices<UserProfile>, IUserProfileServices
    {
        private readonly IDbFactory _dbFactory;
        private readonly IUserProfileRepository _repository;

        public UserProfileServices(IDbFactory dbFactory, IUserProfileRepository repository)
            : base(dbFactory, repository)
        {
            _dbFactory = dbFactory;
            _repository = repository;
        }

        public UserProfile GetByUserName(string userName)
        {
            return _repository.GetUserProfileByUserName(userName);
        }

        public UserProfile GetByUserId(int userId)
        {
            return _repository.GetUserprofileById(userId);
        }
    }
}