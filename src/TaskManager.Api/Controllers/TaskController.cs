using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.ViewModels;
using TaskManager.Business.Interface.Repositories;
using TaskManager.Business.Interface.Services;
using TaskManager.Business.Models;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskJobService _taskJobService;
        private readonly ITaskJobRepository _taskJobRepository;
        private readonly IMapper _mapper;

        public TaskController(ITaskJobService taskJobService, 
                              ITaskJobRepository taskJobRepository, 
                              IMapper mapper)
        {
            _taskJobService = taskJobService;
            _taskJobRepository = taskJobRepository;
            _mapper = mapper;
        }

        [HttpGet("{projectId:guid}")]
        public async Task<IActionResult> GetAllTaskByProjectAsync(Guid projectId)
        {
            return Ok(await _taskJobService.GetTasksByProject(projectId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync([FromBody] TaskJobInputModel taskJobInput)
        {
            if (taskJobInput == null)
            {
                return BadRequest();
            }

            List<TaskJob> tasks = await _taskJobService.GetTasksByProject(taskJobInput.ProjectId);

            if (tasks != null && tasks.Count <= 20)
            {
                var task = _mapper.Map<TaskJob>(taskJobInput);

                return Ok(await _taskJobService.Create(task));
            }

            return BadRequest($"Não foi possivel cadastrar a tarefa, o projeto já possui o limite de vinte tarefas!");
        }

        [HttpPut("{taskId:guid}")]
        public async Task<IActionResult> UpdateTask([FromBody] TaskJobInputUpdateModel taskJobInput, Guid taskId, Guid userIdUpdate)
        {
            TaskJob task = await _taskJobRepository.GetById(taskId);

            if (task == null)
            {
                return BadRequest();
            }

            task.Title = taskJobInput.Title;
            task.Description = taskJobInput.Description;
            task.Status = taskJobInput.Status;

            return Ok(await _taskJobService.Update(task));
        }

        [HttpDelete("{taskId:guid}")]
        public async Task<IActionResult> DeleteTask(Guid taskId)
        {
            TaskJob task = await _taskJobRepository.GetById(taskId);

            if (task == null)
            {
                return BadRequest();
            }

            await _taskJobService.Delete(taskId);

            return Ok();
        }
    }
}
