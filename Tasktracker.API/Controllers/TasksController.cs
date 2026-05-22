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

        [HttpGet("GetLatest")]
        public async Task<IActionResult> GetLatest()
        {
            TaskDTO? result = await TaskService.GetLatestTaskAsync();
            return result == null ? NoContent() : Ok(result);
        }

        [HttpGet("GetCompleted")]
        public async Task<IActionResult> GetCompleted()
        {
            List<TaskListDTO> result = await TaskService.GetCompletedTasksAsync();
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(TaskCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TaskListDTO result = await TaskService.CreateTaskAsync(request);
            return CreatedAtAction(nameof(GetLatest), new { Id = result.Id }, result);
        }

        [HttpPut("UpdateDescription/{id}")]
        public async Task<IActionResult> UpdateDescription(Guid id, TaskEditDescriptionRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id == request.Id)
                return BadRequest("The IDs are not identical.");

            try
            {
                await TaskService.UpdateTaskDescriptionAsync(request);
                return NoContent();
            }
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPut("SetCompleted/{id}")]
        public async Task<IActionResult> SetCompleted(Guid id, TaskSetCompletedRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id == request.Id)
                return BadRequest("The IDs are not identical.");

            try
            {
                await TaskService.SetTaskCompletedAsync(request);
                return NoContent();
            }
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TaskDeleteRequest request = new TaskDeleteRequest()
            {
                Id = id
            };

            try
            {
                await TaskService.DeleteTaskAsync(request);
                return NoContent();
            }
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
