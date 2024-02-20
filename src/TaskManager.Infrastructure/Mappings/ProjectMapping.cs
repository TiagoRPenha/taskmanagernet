using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Business.Models;

namespace TaskManager.Infrastructure.Mappings
{
    public class ProjectMapping : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasMany(p => p.Tasks)
                .WithOne(p => p.Project)
                .HasForeignKey(p => p.ProjectId);

            builder.ToTable("Projects");
        }
    }
}
