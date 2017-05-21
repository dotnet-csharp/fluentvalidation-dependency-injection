using Tut.Entities;

namespace Tut.Repositories
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Blog GetById(int id);
    }
}