using TaskManager.Business.Models;

namespace TaskManager.Business.Interface.Services
{
    public interface ITaskJobService
    {
        Task Create(TaskJob task);
        Task Update(TaskJob task);
        Task Delete(Guid taskId);
        Task<List<TaskJob>> GetTasksByProject(Guid projectId);
    }
}
