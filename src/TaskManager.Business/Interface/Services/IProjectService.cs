using TaskManager.Business.Models;

namespace TaskManager.Business.Interface.Services
{
    public interface IProjectService
    {
        Task<Project> Create(Project project);
        Task<Project> Update(Project project);
        Task Delete(Guid projectId);
        Task<List<Project>> GetAllProjectsByUser(Guid userId);
        Task<bool> ValidateProjectExistsTasksStatusPending(Guid projectId);
    }
}
