using System.ComponentModel.DataAnnotations;

namespace Tasktracker.Application.DTOs.Task
{
    public class TaskEditDescriptionRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
