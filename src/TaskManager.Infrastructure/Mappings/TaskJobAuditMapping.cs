using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Business.Models;

namespace TaskManager.Infrastructure.Mappings
{
    public class TaskJobAuditMapping : IEntityTypeConfiguration<TaskJobAudit>
    {
        public void Configure(EntityTypeBuilder<TaskJobAudit> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UserId)
                .IsRequired()
                .HasColumnType("varchar(80)");

            builder.Property(p => p.FieldChange)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.OldValue)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.NewValue)
              .IsRequired()
              .HasColumnType("varchar(150)");

            builder.Property(p => p.Comment)
                .HasColumnType("varchar(150)");

            builder.ToTable("TaskJobAudit");
        }
    }
}
