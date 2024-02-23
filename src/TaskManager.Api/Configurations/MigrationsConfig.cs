using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Context;

namespace TaskManager.Api.Configurations
{
    public static class MigrationsConfig
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider.GetService<TaskContext>();

                serviceDb.Database.Migrate();
            }
        }
    }
}
