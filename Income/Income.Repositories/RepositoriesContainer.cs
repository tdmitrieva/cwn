using Income.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Income.Repositories
{
    internal class RepositoriesContainer
    {
        private static Dictionary<string, object> repositories = new Dictionary<string, object>();
        private readonly DbContext dbContext;
        public RepositoriesContainer(DbContext context)
        {
            dbContext = context;
        }

        public Repository<TEntity> Resolve<TEntity>() where TEntity : BaseEntity
        {
            string key = typeof(TEntity).Name;
            if (repositories.ContainsKey(key) == false)
            {
                Type repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), dbContext);
                repositories.Add(key, repositoryInstance); 
            }
            return (Repository<TEntity>)repositories[key];
        }

        public void Dispose()
        {
            repositories = null;
        }
    }
}
