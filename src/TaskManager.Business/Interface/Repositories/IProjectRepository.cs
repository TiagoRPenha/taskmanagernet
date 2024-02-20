using TaskManager.Business.Models;

namespace TaskManager.Business.Interface.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<List<Project>> GetProjectByUser(Guid userId);
    }
}
