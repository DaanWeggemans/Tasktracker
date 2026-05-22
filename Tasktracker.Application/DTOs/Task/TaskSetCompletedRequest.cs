using System.ComponentModel.DataAnnotations;

namespace Tasktracker.Application.DTOs.Task
{
    public class TaskSetCompletedRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
