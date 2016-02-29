using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int key);
        TEntity GetByPredicate(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
