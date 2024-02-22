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
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, 
                                 IProjectRepository projectRepository, 
                                 IMapper mapper)
        {
            _projectService = projectService;
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetAllProjectsByUserAsync(Guid userId)
        {
            return Ok(await _projectService.GetAllProjectsByUser(userId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectAsync([FromBody] ProjectInputModel projetInput)
        {
            if (projetInput == null)
            {
                return BadRequest();
            }

            Project project = _mapper.Map<Project>(projetInput);

            return Ok(await _projectService.Create(project));
        }

        [HttpDelete("{projectId:guid}")]
        public async Task<IActionResult> DeleteProjectAsync(Guid projectId)
        {
            Project project = await _projectRepository.GetById(projectId);

            if (project == null)
            {
                return BadRequest("Não existe projeto cadastrado com este Id.");
            }

            bool existsTasksWithStatusPending = await _projectService.ValidateProjectExistsTasksStatusPending(projectId);

            if(existsTasksWithStatusPending)
            {
                return BadRequest("O projeto possui tarefas pendentes, conclua ou remova as tarefas para prosseguir com a exclusão do projeto!");
            }

            await _projectService.Delete(projectId);
            
            return Ok();
        }
    }
}
