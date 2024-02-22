using NSubstitute;
using TaskManager.Business.Interface.Repositories;
using TaskManager.Business.Models;
using TaskManager.Business.Services;

namespace TaskManager.Tests.Entities
{
    public class TaskJobTests
    {
        [Fact]
        public async void TestCreateTask()
        {
            //Arrange
            const string title = "Task BackEnd - ";
            Guid guidEntityId = Guid.NewGuid();

            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = "Task API",
                UserId = Guid.NewGuid()
            };

            IProjectRepository projectRepository = Substitute.For<IProjectRepository>();
            projectRepository.Create(project).Returns(project);

            var task = new TaskJob
            {
                Id = guidEntityId,
                Title = title + guidEntityId.ToString(),
                Description = "BackEnd/xUnit",
                ProjectId = project.Id,
            };

            ITaskJobRepository taskJobRepository = Substitute.For<ITaskJobRepository>();
            taskJobRepository.Create(task).Returns(task);

            var projectService = new ProjectService(projectRepository, taskJobRepository);
            var taskJobService = new TaskJobService(taskJobRepository);

            //Act
            var resultProject = await projectService.Create(project);
            var resultTaskJob = await taskJobService.Create(task);

            //Assert
            Assert.NotNull(resultProject);
            Assert.NotNull(resultTaskJob);
            projectRepository.Received().Create(project);
            Assert.Equal(task.Title, resultTaskJob.Title);
            Assert.Equal(task.Description, resultTaskJob.Description);
        }

        [Fact]
        public async void TestDeleteTask()
        {
            //Arrange
            const string title = "Task BackEnd - ";
            Guid guidEntityId = Guid.NewGuid();

            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = "Task API",
                UserId = Guid.NewGuid()
            };

            IProjectRepository projectRepository = Substitute.For<IProjectRepository>();
            projectRepository.Create(project).Returns(project);

            var task = new TaskJob
            {
                Id = guidEntityId,
                Title = title + guidEntityId.ToString(),
                Description = "BackEnd/xUnit",
                ProjectId = project.Id,
            };

            ITaskJobRepository taskJobRepository = Substitute.For<ITaskJobRepository>();
            taskJobRepository.Create(task).Returns(task);
            taskJobRepository.Delete(task.Id);
            taskJobRepository.GetById(task.Id).Returns(task);

            var projectService = new ProjectService(projectRepository, taskJobRepository);
            var taskJobService = new TaskJobService(taskJobRepository);

            //Act
            await projectService.Create(project);
            await taskJobService.Create(task);
            await taskJobService.Delete(task.Id);

            var projectDelete = await taskJobRepository.GetById(task.Id);

            //Assert
            Assert.Null(projectDelete);
        }

        [Fact]
        public async void TestUpdateTask()
        {
            //Arrange
            const string title = "TASK API - ";
            Guid guidEntityId = Guid.NewGuid();

            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = "Task API",
                UserId = Guid.NewGuid()
            };

            IProjectRepository projectRepository = Substitute.For<IProjectRepository>();
            projectRepository.Create(project).Returns(project);

            var task = new TaskJob
            {
                Id = guidEntityId,
                Title = title + guidEntityId.ToString(),
                Description = "BackEnd/xUnit",
                ProjectId = project.Id,
            };

            ITaskJobRepository taskJobRepository = Substitute.For<ITaskJobRepository>();
            taskJobRepository.Create(task).Returns(task);
            taskJobRepository.Update(task).Returns(task);

            var projectService = new ProjectService(projectRepository, taskJobRepository);
            var taskJobService = new TaskJobService(taskJobRepository);

            //Act
            await projectService.Create(project);
            await taskJobService.Create(task);

            task.Title = "UPDATE TASK";

            var taskUpdate = await taskJobService.Update(task);

            //Assert
            Assert.Equal(task.Title, taskUpdate.Title);
            Assert.Equal(task.Description, taskUpdate.Description);
        }
        [Fact]
        public async void TestGetTasksByProject()
        {
            //Arrange
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = "PROJECT API",
                UserId = Guid.NewGuid()
            };

            IProjectRepository projectRepository = Substitute.For<IProjectRepository>();
            projectRepository.Create(project).Returns(project);

            List<TaskJob> tasks = new List<TaskJob>()
            {
                new TaskJob { Title = "Task One", Status = Business.Models.Enums.Status.Pending, ProjectId = project.Id },
                new TaskJob { Title = "Task Two", Status = Business.Models.Enums.Status.Completed, ProjectId = project.Id },
                new TaskJob { Title = "Task Three ", Status = Business.Models.Enums.Status.InProgress, ProjectId = project.Id }
            };

            ITaskJobRepository taskJobRepository = Substitute.For<ITaskJobRepository>();
            foreach (var taskJob in tasks)
            {
                taskJobRepository.Create(taskJob).Returns(taskJob);
                taskJobRepository.GetTasksByProject(taskJob.ProjectId).Returns(tasks);
            }

            var projectService = new ProjectService(projectRepository, taskJobRepository);
            var taskJobService = new TaskJobService(taskJobRepository);

            //Act
            await projectService.Create(project);

            foreach (var task in tasks)
            {
                await taskJobService.Create(task);
            }

            var tasksByProject = await taskJobService.GetTasksByProject(project.Id);

            //Assert
            Assert.NotNull(tasksByProject);
            Assert.NotEmpty(tasksByProject);
        }
    }
}
