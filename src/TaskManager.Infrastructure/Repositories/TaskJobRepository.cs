using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Interface.Repositories;
using TaskManager.Business.Models;
using TaskManager.Infrastructure.Context;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskJobRepository : BaseRepository<TaskJob>, ITaskJobRepository
    {
        public TaskJobRepository(TaskContext context) : base(context)
        {
        }

        public async Task<List<TaskJob>> GetTasksByProject(Guid projectId)
        {
            return await _dbEntities.AsNoTracking().Where(p => p.ProjectId == projectId).ToListAsync();
        }

        public async Task RemoveTaskProject(Guid taskId, Guid projectId)
        {
            throw new NotImplementedException();
        }


        //REVER SE ESTE METODO ESTA CERTO AQUI OU NA CLASSE PROJECTREPOSITORY
        public Task AddTaskToProject(TaskJob task, Guid projectId)
        {
            throw new NotImplementedException();
        }
    }
}
