using Moq;
using Tasktracker.Application.DTOs.Task;
using Tasktracker.Application.Interfaces.Repositories;
using Tasktracker.Application.Services;
using Tasktracker.Domain.Entities;
using Tasktracker.Tests.Factories;

namespace Tasktracker.Tests
{
    public class TaskTests
    {
        private readonly Mock<ITaskRepository> _taskRepository;

        private readonly TaskService _taskService;

        public TaskTests()
        {
            _taskRepository = new Mock<ITaskRepository>();

            _taskService = new TaskService(_taskRepository.Object);
        }

        [Fact]
        public async Task UpdateTaskDescriptionAsync_ValidRequest_Success()
        {
            // Arrange
            TTask task = TTaskFactory.Create();
            TaskEditDescriptionRequest request = new TaskEditDescriptionRequest()
            {
                Id = task.Id,
                Description = "Dit is een nieuwe beschrijving."
            };

            _taskRepository.Setup(repository => repository.GetByIdAsync(task.Id))
                .ReturnsAsync(task);

            // Act
            TaskDTO? updatedTask = await _taskService.UpdateTaskDescriptionAsync(request);

            // Assert
            Assert.NotNull(updatedTask);
            Assert.Equal(updatedTask.Id, request.Id);
            Assert.Equal(updatedTask.Description, request.Description);
        }

        [Fact]
        public async Task UpdateTaskDescriptionAsync_NotFound_ThrowsArgumentNullException()
        {
            // Arrange
            TaskEditDescriptionRequest request = new TaskEditDescriptionRequest()
            {
                Id = Guid.NewGuid(),
                Description = "Dit is een nieuwe beschrijving."
            };

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _taskService.UpdateTaskDescriptionAsync(request));
        }

        [Fact]
        public async Task SetTaskCompletedAsync_ValidRequest_Success()
        {
            // Arrange
            TTask task = TTaskFactory.Create();
            task.IsDone = false;

            TaskSetCompletedRequest request = new TaskSetCompletedRequest()
            {
                Id = task.Id
            };

            _taskRepository.Setup(repository => repository.GetByIdAsync(task.Id))
                .ReturnsAsync(task);

            // Act
            TaskDTO? updatedTask = await _taskService.SetTaskCompletedAsync(request);

            // Assert
            Assert.NotNull(updatedTask);
            Assert.True(updatedTask.IsDone);
        }

        [Fact]
        public async Task SetTaskCompletedAsync_NotFound_ThrowsArgumentNullException()
        {
            // Arrange
            TaskSetCompletedRequest request = new TaskSetCompletedRequest()
            {
                Id = Guid.NewGuid()
            };

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _taskService.SetTaskCompletedAsync(request));
        }

        [Fact]
        public async Task DeleteTaskAsync_NotFound_ThrowsArgumentNullException()
        {
            // Arrange
            TaskDeleteRequest request = new TaskDeleteRequest()
            {
                Id = Guid.NewGuid()
            };

            await Assert.ThrowsAsync<ArgumentNullException>(() => _taskService.DeleteTaskAsync(request));
        }

        [Fact]
        public async Task GetCompletedTasksAsync_Success()
        {
            // Arrange
            List<TTask> tasks = new List<TTask>();
            for (int i = 0; i < 50; i++)
                tasks.Add(TTaskFactory.Create());

            tasks = tasks.Where(task => task.IsDone).ToList();

            _taskRepository.Setup(repository => repository.GetCompletedTasksAsync())
                .ReturnsAsync(tasks);

            // Act
            List<TaskListDTO> completedTasks = await _taskService.GetCompletedTasksAsync();

            // Assert
            Assert.Equal(tasks.Count, completedTasks.Count);
        }
    }
}
