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
            return await _dbEntities.Where(p => p.ProjectId == projectId).ToListAsync();
        }

        //REVER SE ESTE METODO ESTA CERTO AQUI OU NA CLASSE PROJECTREPOSITORY
        public async Task AddTaskToProject(Task task, Guid projectId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveTaskProject(Guid taskId, Guid projectId)
        {
            throw new NotImplementedException();
        }
    }
}
