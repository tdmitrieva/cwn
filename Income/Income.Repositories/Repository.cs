using Income.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Income.Repositories
{
    public class Repository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext context;
        protected IDbSet<TEntity> entities;
        public Repository(DbContext dbContext)
        {
            context = dbContext;
            entities = context.Set<TEntity>();
        }

        public virtual TEntity GetById(object id)
        {
            return entities.Find(id);
        }

        public virtual IQueryable<TEntity> Query()
        {
            return entities;
        }

        public virtual void Create(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("Entity could not be null.");
            }
            entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity could not be null.");
            }
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            entities.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entity = GetById(id);
            if(entity != null)
            {
                entities.Remove(entity);
            }
        }
    }
}
