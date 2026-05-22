using System.ComponentModel.DataAnnotations;

namespace Tasktracker.Application.DTOs.Task
{
    public class TaskCreateRequest
    {
        [Required, MinLength(3)]
        public required string Title { get; set; }
        [Required]
        public required string Description { get; set; }
        public bool? IsDone { get; set; }
    }
}
