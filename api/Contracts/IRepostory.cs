using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyTeam.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IList<TEntity> GetAll();
        IList<TEntity> Find(Expression<Func<TEntity,bool>> predicate);
        void Add(TEntity entity);        
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}