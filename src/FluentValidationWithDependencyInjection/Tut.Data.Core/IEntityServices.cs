using System.Collections.Generic;
using Tut.Entities;

namespace Tut.Services
{
    public interface IEntityServices<T> : IServices where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}