using TaskManager.Business.Models;

namespace TaskManager.Business.Interface.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(Guid id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<int> SaveChanges();
    }
}
