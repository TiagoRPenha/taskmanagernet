using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Business.Models;

namespace TaskManager.Infrastructure.Mappings
{
    public class TaskJobMapping : IEntityTypeConfiguration<TaskJob>
    {
        public void Configure(EntityTypeBuilder<TaskJob> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasColumnType("varchar(80)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(150");

            builder.Property(p => p.Comment)
                .HasColumnType("varchar(100)");

            builder.ToTable("TasksJobs");
        }
    }
}
