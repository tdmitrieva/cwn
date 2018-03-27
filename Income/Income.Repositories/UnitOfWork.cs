using Income.Models;
using System;

namespace Income.Repositories
{
    internal class UnitOfWork : IDisposable, IUnitOfWork
    {
        private static readonly IncomeDbContext dbContext = new IncomeDbContext();
        private readonly RepositoriesContainer repositoriesContainer;
        private bool disposed = false;

        public UnitOfWork()
        {
            repositoriesContainer = new RepositoriesContainer(dbContext);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public Repository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            return repositoriesContainer.Resolve<TEntity>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    repositoriesContainer.Dispose();
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
