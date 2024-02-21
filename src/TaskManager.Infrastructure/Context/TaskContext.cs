using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Models;
using TaskManager.Business.Models.Enums;

namespace TaskManager.Infrastructure.Context
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<TaskJob> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskJobAudit> TaskAudit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await BeforeSaveChanges();
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private async Task BeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries().ToList())
            {
                if (entry.Entity is TaskJobAudit auditable)
                {
                    auditable.UpdateDateModified(entry.State);
                }

                if (entry.Entity is TaskJobAudit || entry.State is EntityState.Detached or EntityState.Unchanged)
                {
                    continue;
                }

                var auditEntry = new AuditEntry(entry) { };

                foreach (var property in entry.Properties)
                {
                    var propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    if (entry.State == EntityState.Modified && property.IsModified)
                    {
                        auditEntry.ChangedColumns.Add(propertyName);
                        auditEntry.AuditType = AuditType.Update;
                        auditEntry.OldValues[propertyName] = property.OriginalValue;
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                    }

                    await TaskAudit.AddAsync(auditEntry.ToAudit());
                }
            }
        }
    }
}
