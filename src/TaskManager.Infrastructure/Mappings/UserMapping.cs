using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Business.Models;

namespace TaskManager.Infrastructure.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Projects)
                  .WithOne(p => p.User)
                  .HasForeignKey(p => p.UserId);

            builder.ToTable("Users");
        }
    }
}
