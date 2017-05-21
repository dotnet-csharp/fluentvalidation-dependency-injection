using System;
using System.Collections.Generic;
using Tut.Entities;
using Tut.Repositories;

namespace Tut.Services
{
    public abstract class EntityServices<T> : IEntityServices<T> where T : BaseEntity
    {
        private readonly IDbFactory _dbFactory;
        private readonly IGenericRepository<T> _repository;

        protected EntityServices(IDbFactory dbFactory, IGenericRepository<T> repository)
        {
            _dbFactory = dbFactory;
            _repository = repository;
        }

        public virtual void Create(T entity)
        {
            AssertNotNull(entity);
            _dbFactory.Commit();
        }

        public virtual void Delete(T entity)
        {
            AssertNotNull(entity);
            _repository.Edit(entity);
            _dbFactory.Commit();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Update(T entity)
        {
            AssertNotNull(entity);
            _repository.Edit(entity);
            _dbFactory.Commit();
        }

        private static void AssertNotNull(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");
        }
    }
}