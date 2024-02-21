using TaskManager.Business.Models;

namespace TaskManager.Business.Interface.Services
{
    public interface IProjectService
    {
        Task Create(Project project);
        Task Update(Project project);
        Task Delete(Guid projectId);
        Task<List<Project>> GetProjectByUser(Guid userId);
        Task<bool> ValidateProjectExistsTasksStatusPending(Guid projectId);
    }
}
