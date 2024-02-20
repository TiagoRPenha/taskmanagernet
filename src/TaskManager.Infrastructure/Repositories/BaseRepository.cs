using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Interface.Repositories;
using TaskManager.Business.Models;
using TaskManager.Infrastructure.Context;

namespace TaskManager.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly TaskContext _context;
        protected readonly DbSet<TEntity> _dbEntities;

        protected BaseRepository(TaskContext context)
        {
            _context = context;
            _dbEntities = context.Set<TEntity>();            
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbEntities.ToListAsync();
        }
        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbEntities.FindAsync(id);
        }
        public async Task Create(TEntity entity)
        {
            _dbEntities.Add(entity);

            await SaveChanges();
        }
        public async Task Update(TEntity entity)
        {
            _dbEntities.Update(entity);

            await SaveChanges();
        }
        public async Task Delete(Guid id)
        {
            _dbEntities.Remove(new TEntity { Id = id });

            await SaveChanges();
        }
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();   
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
