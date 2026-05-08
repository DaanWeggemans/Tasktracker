namespace Tasktracker.Application.DTOs.Task
{
    public class TaskListDTO
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
