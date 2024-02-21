using TaskManager.Business.Models;

namespace TaskManager.Business.Interface.Services
{
    public interface IReportService
    {
        Task<List<TaskJobAudit>> GetAllTasksByUser(Guid userId);
    }
}
