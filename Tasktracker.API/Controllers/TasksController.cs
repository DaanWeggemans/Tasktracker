using Microsoft.AspNetCore.Mvc;
using Tasktracker.Application.DTOs.Task;
using Tasktracker.Application.Interfaces.Services;

namespace Tasktracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService TaskService;

        public TasksController(ITaskService taskService)
        {
            TaskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            TaskDTO? result = await TaskService.GetLatestTaskAsync();
            return result == null ? NoContent() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TaskListDTO result = await TaskService.CreateTaskAsync(request);
            return CreatedAtAction(nameof(Get), new { Id = result.Id }, result);
        }
    }
}
