using Income.Models;

namespace Income.Repositories
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Repository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
