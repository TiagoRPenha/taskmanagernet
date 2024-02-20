using TaskManager.Business.Interface.Repositories;
using TaskManager.Infrastructure.Context;
using TaskManager.Infrastructure.Repositories;

namespace TaskManager.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<TaskContext>();

            services.AddTransient<ITaskJobRepository, TaskJobRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();

            return services;
        }
    }
}
