using Tasktracker.Application.DTOs.Task;
using Tasktracker.Application.Extensions;
using Tasktracker.Application.Interfaces.Repositories;
using Tasktracker.Application.Interfaces.Services;
using Tasktracker.Domain.Entities;

namespace Tasktracker.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<TTask> TaskRepository;

        public TaskService(IRepository<TTask> taskRepository)
        {
            TaskRepository = taskRepository;
        }

        public async Task<TaskDTO?> GetLatestTaskAsync()
        {
            TTask? task = await TaskRepository.GetLatestAsync();
            return task == null ? null : task.ToTaskDTO();
        }

        public async Task<TaskListDTO> CreateTaskAsync(TaskCreateRequest request)
        {
            TTask task = await TaskRepository.CreateAsync(request.ToTask());
            return task.ToTaskListDTO();
        }
    }
}
