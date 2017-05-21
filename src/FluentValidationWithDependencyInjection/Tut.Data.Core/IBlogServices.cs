using Tut.Entities;

namespace Tut.Services
{
    public interface IBlogServices : IEntityServices<Blog>
    {
        Blog GetById(int id);
    }
}