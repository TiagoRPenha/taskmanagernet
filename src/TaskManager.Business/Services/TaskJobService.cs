using TaskManager.Business.Interface.Repositories;
using TaskManager.Business.Interface.Services;
using TaskManager.Business.Models;

namespace TaskManager.Business.Services
{
    public class TaskJobService : ITaskJobService
    {
        private readonly ITaskJobRepository _taskRepository;

        public TaskJobService(ITaskJobRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task Create(TaskJob task)
        {
            await _taskRepository.Create(task);
        }

        public async Task Delete(Guid taskId)
        {
            await _taskRepository.Delete(taskId);
        }

        public async Task<List<TaskJob>> GetTasksByProject(Guid projectId)
        {
            return await _taskRepository.GetTasksByProject(projectId);
        }

        public async Task Update(TaskJob task)
        {
            await _taskRepository.Update(task);
        }
    }
}
