using Tasktracker.Application.DTOs.Task;
using Tasktracker.Application.Extensions;
using Tasktracker.Application.Interfaces.Repositories;
using Tasktracker.Application.Interfaces.Services;
using Tasktracker.Domain.Entities;

namespace Tasktracker.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository TaskRepository;

        public TaskService(ITaskRepository taskRepository)
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

        public async Task<TaskDTO> UpdateTaskDescriptionAsync(TaskEditDescriptionRequest request)
        {
            TTask? task = await TaskRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ArgumentNullException("Task not found.");

            task.Description = request.Description;
            await TaskRepository.UpdateAsync(task);
            return task.ToTaskDTO();
        }

        public async Task<TaskDTO> SetTaskCompletedAsync(TaskSetCompletedRequest request)
        {
            TTask? task = await TaskRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ArgumentNullException("Task not found.");

            task.IsDone = true;
            await TaskRepository.UpdateAsync(task);
            return task.ToTaskDTO();
        }

        public async Task DeleteTaskAsync(TaskDeleteRequest request)
        {
            TTask? task = await TaskRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ArgumentNullException("Task not found.");

            await TaskRepository.DeleteAsync(task);
        }

        public async Task<List<TaskListDTO>> GetCompletedTasksAsync()
        {
            List<TTask> tasks = await TaskRepository.GetCompletedTasksAsync();
            return tasks.Select(task => task.ToTaskListDTO()).ToList();
        }
    }
}
