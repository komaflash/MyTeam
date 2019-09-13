using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyTeam.Contracts;

namespace MyTeam.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> entities;

        public Repository(DbContext context)
        {
            entities = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            entities.Remove(entity);
        }

        public IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return entities.Where(predicate).ToList();
        }

        public TEntity Get(int id)
        {
            return entities.Find(id);
        }

        public IList<TEntity> GetAll()
        {
            return entities.ToList();
        }

        public void Update(TEntity entity)
        {
            entities.Update(entity);            
        }
    }
}