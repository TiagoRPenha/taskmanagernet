using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Interface.Repositories;
using TaskManager.Business.Models;
using TaskManager.Infrastructure.Context;

namespace TaskManager.Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(TaskContext context) : base(context) { }

        public async Task<List<Project>> GetProjectByUser(Guid userId)
        {
            return await _dbEntities.AsNoTracking().Where(p => p.UserId == userId).ToListAsync();
        }
    }
}
