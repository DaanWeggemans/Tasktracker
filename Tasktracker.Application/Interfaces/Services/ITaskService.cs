using Tasktracker.Application.DTOs.Task;

namespace Tasktracker.Application.Interfaces.Services
{
    public interface ITaskService
    {
        Task<TaskDTO?> GetLatestTaskAsync();
        Task<TaskListDTO> CreateTaskAsync(TaskCreateRequest request);
        Task<TaskDTO> UpdateTaskDescriptionAsync(TaskEditDescriptionRequest request);
        Task<TaskDTO> SetTaskCompletedAsync(TaskSetCompletedRequest request);
        Task DeleteTaskAsync(TaskDeleteRequest request);
        Task<List<TaskListDTO>> GetCompletedTasksAsync();
    }
}
