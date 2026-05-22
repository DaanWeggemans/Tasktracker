using Tasktracker.Application.DTOs.Task;
using Tasktracker.Domain.Entities;

namespace Tasktracker.Application.Extensions
{
    public static class TaskExtensions
    {
        public static TTask ToTask(this TaskCreateRequest request)
        {
            return new TTask()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                IsDone = request.IsDone ?? false
            };
        }

        public static TaskDTO ToTaskDTO(this TTask task)
        {
            return new TaskDTO()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsDone = task.IsDone,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt
            };
        }

        public static TaskListDTO ToTaskListDTO(this TTask task)
        {
            return new TaskListDTO()
            {
                Id = task.Id,
                Title = task.Title,
                IsDone = task.IsDone
            };
        }
    }
}
