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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ITaskJobService _taskJobService;
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IProjectRepository projectRepository, ITaskJobService taskJobService, IMapper mapper)
        {
            _projectService = projectService;
            _projectRepository = projectRepository;
            _taskJobService = taskJobService;
            _mapper = mapper;
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetAllProjectsByUser(Guid userId)
        {
            return Ok(await _projectService.GetProjectByUser(userId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectInputModel projetInput)
        {
            if (projetInput == null)
            {
                return BadRequest();
            }

            var project = _mapper.Map<Project>(projetInput);

            await _projectService.Create(project);

            return Ok();
        }

        [HttpDelete("{projectId:guid}")]
        public async Task<IActionResult> DeleteProject(Guid projectId)
        {
            var result = await _projectRepository.GetById(projectId);

            if (result == null)
            {
                return BadRequest("Não existe projeto cadastrado com este Id.");
            }

            var existsTasksPending = await _projectService.ValidateProjectExistsTasksStatusPending(projectId);

            if(existsTasksPending)
            {
                return BadRequest("O projeto possui tarefas pendentes, conclua ou remova as tarefas para prosseguir com a exclusão do projeto!");
            }

            await _projectService.Delete(projectId);
            
            return Ok();
        }
    }
}
