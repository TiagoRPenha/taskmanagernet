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
            return await _dbEntities.AsNoTracking().ToListAsync();
        }
        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbEntities.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<TEntity> Create(TEntity entity)
        {
            _dbEntities.Add(entity);

            await SaveChanges();

            return entity;
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            _dbEntities.Update(entity);

            await SaveChanges();

            return entity;
        }
        public async Task Delete(Guid id)
        {
            TEntity entity = new TEntity
            {
                Id = id 
            };

            _context.Entry(entity).State = EntityState.Detached;
            _context.Remove(entity);            

            await SaveChanges();
        }
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
