using TaskManager.Business.Models;

namespace TaskManager.Business.Interface.Services
{
    public interface ITaskJobService
    {
        Task<TaskJob> Create(TaskJob task);
        Task<TaskJob> Update(TaskJob task);
        Task Delete(Guid taskId);
        Task<List<TaskJob>> GetTasksByProject(Guid projectId);
    }
}
