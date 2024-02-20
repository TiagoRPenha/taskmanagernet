using TaskManager.Business.Models;

namespace TaskManager.Business.Interface.Repositories
{
    public interface ITaskJobRepository : IBaseRepository<TaskJob>
    {
        Task<List<TaskJob>> GetTasksByProject(Guid projectId);
        Task AddTaskToProject(Task task, Guid projectId);
        Task RemoveTaskProject(Guid taskId, Guid projectId);
    }
}
