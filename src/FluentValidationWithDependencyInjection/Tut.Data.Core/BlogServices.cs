using Tut.Entities;
using Tut.Repositories;

namespace Tut.Services
{
    public class BlogServices : EntityServices<Blog>, IBlogServices
    {
        private readonly IDbFactory _dbFactory;
        private readonly IBlogRepository _repository;

        public BlogServices(IDbFactory dbFactory, IBlogRepository repository) : base(dbFactory, repository)
        {
            _dbFactory = dbFactory;
            _repository = repository;
        }

        public Blog GetById(int id)
        {
            return _repository.Find(x => id);
        }
    }
}