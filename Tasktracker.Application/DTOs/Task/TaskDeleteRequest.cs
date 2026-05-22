using System.ComponentModel.DataAnnotations;

namespace Tasktracker.Application.DTOs.Task
{
    public class TaskDeleteRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
