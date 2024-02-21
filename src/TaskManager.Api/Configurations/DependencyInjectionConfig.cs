using TaskManager.Business.Interface.Repositories;
using TaskManager.Business.Interface.Services;
using TaskManager.Business.Services;
using TaskManager.Infrastructure.Context;
using TaskManager.Infrastructure.Repositories;

namespace TaskManager.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<TaskContext>();

            services.AddScoped<ITaskJobRepository, TaskJobRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskJobService, TaskJobService>();

            return services;
        }
    }
}
