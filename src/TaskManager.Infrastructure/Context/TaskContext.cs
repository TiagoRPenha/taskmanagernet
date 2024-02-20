using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Models;

namespace TaskManager.Infrastructure.Context
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<TaskJob> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskJobAudit> TaskAudit { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
