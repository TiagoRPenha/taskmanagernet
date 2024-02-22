using NSubstitute;
using TaskManager.Business.Interface.Repositories;
using TaskManager.Business.Models;
using TaskManager.Business.Services;

namespace TaskManager.Tests.Entities
{
    public class ProjectTests
    {
        [Fact]
        public async void TestCreateProject()
        {
            //Arrange
            const string title = "Project API - ";
            Guid guidEntityId = Guid.NewGuid();

            var project = new Project
            {
                Id = guidEntityId,
                Name = title + guidEntityId.ToString(),
                Tasks = new List<TaskJob> { },
                UserId = Guid.NewGuid()
            };

            IProjectRepository projectRepository = Substitute.For<IProjectRepository>();
            projectRepository.Create(project).Returns(project);

            var projectService = new ProjectService(projectRepository, null);

            //Act
            var result = await projectService.Create(project);

            //Assert
            Assert.NotNull(result);
            projectRepository.Received().Create(project);
            Assert.Equal(project.Name, result.Name);
        }

        [Fact]
        public async void TestDeleteProject()
        {
            //Arrange
            const string title = "Project API - ";
            Guid guidEntityId = Guid.NewGuid();

            var project = new Project
            {
                Id = guidEntityId,
                Name = title + guidEntityId.ToString(),
                Tasks = new List<TaskJob> { },
                UserId = Guid.NewGuid()
            };

            IProjectRepository projectRepository = Substitute.For<IProjectRepository>();
            projectRepository.Create(project).Returns(project);

            var projectService = new ProjectService(projectRepository, null);

            //Act
            var result = await projectService.Create(project);

            await projectService.Delete(result.Id);

            var projectDelete = projectRepository.GetById(result.Id);

            //Assert
            Assert.NotNull(result);
            projectRepository.Received().Delete(result.Id); ;
        }

        [Fact]
        public async void TestUpdateProject()
        {
            //Arrange
            const string title = "Project API - ";
            Guid guidEntityId = Guid.NewGuid();

            var project = new Project
            {
                Id = guidEntityId,
                Name = title + guidEntityId.ToString(),
                Tasks = new List<TaskJob> { },
                UserId = Guid.NewGuid()
            };

            IProjectRepository projectRepository = Substitute.For<IProjectRepository>();
            projectRepository.Create(project).Returns(project);
            projectRepository.Update(project).Returns(project);

            var projectService = new ProjectService(projectRepository, null);

            //Act
            var result = await projectService.Create(project);

            project.Name = "UPDATE API";

            var projectUpdate = await projectService.Update(project);

            //Assert
            Assert.NotNull(result);
            projectRepository.Received().Update(project);
            Assert.Equal(project.Name, projectUpdate.Name);
        }
        [Fact]
        public async void TestGetProjectByUser()
        {
            //Arrange
            const string title = "Project API - ";
            Guid userId = Guid.NewGuid();

            List<Project> projects = new List<Project>()
            {
                new Project
                {
                    Id = Guid.NewGuid(),
                    Name = title + Guid.NewGuid().ToString(),
                    Tasks = new List<TaskJob> { },
                    UserId = userId
                },
                new Project
                {
                    Id = Guid.NewGuid(),
                    Name = title + Guid.NewGuid().ToString(),
                    Tasks = new List<TaskJob> { },
                    UserId = userId
                }
            };

            IProjectRepository projectRepository = Substitute.For<IProjectRepository>();

            foreach (var project in projects)
            {
                projectRepository.Create(project).Returns(project);
            }

            projectRepository.GetProjectByUser(userId).Returns(projects);

            var projectService = new ProjectService(projectRepository, null);

            //Act
            foreach (var project in projects)
            {
                projectRepository.Create(project);
            }

            var projectUser = await projectService.GetAllProjectsByUser(userId);

            //Assert
            Assert.NotNull(projectUser);
            Assert.Equal(projects.Count, projectUser.Count);
        }
        [Fact]
        public async void TestValidateProjectExistsTasksStatusPending()
        {
            //Arrange
            const string title = "Project API - ";
            Guid projectId = Guid.NewGuid();

            var project = new Project
            {
                Id = projectId,
                Name = title + Guid.NewGuid().ToString(),
                Tasks = new List<TaskJob>(),
                UserId = Guid.NewGuid()
            };

            IProjectRepository projectRepository = Substitute.For<IProjectRepository>();
            projectRepository.Create(project).Returns(project);

            List<TaskJob> tasks = new List<TaskJob>()
            {
                new TaskJob { Title = "Task One", Status = Business.Models.Enums.Status.Pending, ProjectId = projectId },
                new TaskJob { Title = "Task Two", Status = Business.Models.Enums.Status.Completed, ProjectId = projectId },
                new TaskJob { Title = "Task Three ", Status = Business.Models.Enums.Status.InProgress, ProjectId = projectId }
            };

            ITaskJobRepository taskJobRepository = Substitute.For<ITaskJobRepository>();
            foreach (var taskJob in tasks)
            {
                taskJobRepository.Create(taskJob).Returns(taskJob);
            }

            taskJobRepository.GetTasksByProject(projectId).Returns(tasks);

            var projectService = new ProjectService(projectRepository, taskJobRepository);

            //Act
            var resultProject = await projectRepository.Create(project);

            foreach (var taskJob in tasks)
            {
                await taskJobRepository.Create(taskJob);
            }

            var existsTasksPending = await projectService.ValidateProjectExistsTasksStatusPending(resultProject.Id);

            //Assert
            Assert.True(existsTasksPending);
        }
    }
}

