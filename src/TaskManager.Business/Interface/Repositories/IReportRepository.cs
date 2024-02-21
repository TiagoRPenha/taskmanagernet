using TaskManager.Business.Models;

namespace TaskManager.Business.Interface.Repositories
{
    public interface IReportRepository
    {
        Task<List<TaskJobAudit>> GetAllTasksByUser(Guid userId);
    }
}
