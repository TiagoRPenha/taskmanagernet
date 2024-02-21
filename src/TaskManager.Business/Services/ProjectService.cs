using TaskManager.Business.Interface.Repositories;
using TaskManager.Business.Interface.Services;
using TaskManager.Business.Models;
using TaskManager.Business.Models.Enums;

namespace TaskManager.Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskJobRepository _jobRepository;

        public ProjectService(IProjectRepository projectRepository, ITaskJobRepository jobRepository)
        {
            _projectRepository = projectRepository;
            _jobRepository = jobRepository;
        }

        public async Task Create(Project project)
        {
            await _projectRepository.Create(project);
        }
        public async Task Update(Project project)
        {
            await _projectRepository.Update(project);
        }

        public async Task Delete(Guid projectId)
        {
            await _projectRepository.Delete(projectId);
        }

        public async Task<List<Project>> GetProjectByUser(Guid userId)
        {
            return await _projectRepository.GetProjectByUser(userId);
        }

        public async Task<bool> ValidateProjectExistsTasksStatusPending(Guid projectId)
        {
            var tasks = await _jobRepository.GetTasksByProject(projectId);

            return tasks.Any(task => task.Status == Status.Pending);
        }
    }
}
