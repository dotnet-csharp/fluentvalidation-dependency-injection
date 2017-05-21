using Tut.Entities;

namespace Tut.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(DIContext context) : base(context)
        {
        }

        public Blog GetById(int id)
        {
            return Find(x => id);
        }
    }
}