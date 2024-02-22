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

        public async Task<TaskJob> Create(TaskJob task)
        {
            return await _taskRepository.Create(task);
        }

        public async Task<TaskJob> Update(TaskJob task)
        {
            return await _taskRepository.Update(task);
        }

        public async Task Delete(Guid taskId)
        {
            await _taskRepository.Delete(taskId);
        }

        public async Task<List<TaskJob>> GetTasksByProject(Guid projectId)
        {
            return await _taskRepository.GetTasksByProject(projectId);
        }
    }
}
