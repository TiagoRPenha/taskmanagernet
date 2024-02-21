using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Interface.Repositories;
using TaskManager.Business.Models;
using TaskManager.Infrastructure.Context;

namespace TaskManager.Infrastructure.Repositories
{
    public class ReportRepository : BaseRepository<TaskJobAudit>, IReportRepository
    {
        public ReportRepository(TaskContext context) : base(context)
        {
        }

        public async Task<List<TaskJobAudit>> GetAllTasksByUser(Guid userId)
        {
            return await _dbEntities.Where(p => p.UserId == userId).ToListAsync();
        }
    }
}
