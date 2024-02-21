using TaskManager.Business.Interface.Repositories;
using TaskManager.Business.Interface.Services;
using TaskManager.Business.Models;

namespace TaskManager.Business.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<List<TaskJobAudit>> GetAllTasksByUser(Guid userId)
        {
            var tasks = await _reportRepository.GetAllTasksByUser(userId);

            var tasksPending = (from task in tasks select task)
                                  .ToList();

            return tasksPending;
        }
    }
}
