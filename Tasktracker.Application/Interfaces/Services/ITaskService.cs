using Tasktracker.Application.DTOs.Task;
using Tasktracker.Domain.Entities;

namespace Tasktracker.Application.Interfaces.Services
{
    public interface ITaskService
    {
        Task<TaskDTO?> GetLatestTaskAsync();
        Task<TaskListDTO> CreateTaskAsync(TaskCreateRequest request);
    }
}
