using Tasktracker.Domain.Entities;

namespace Tasktracker.Application.Interfaces.Repositories
{
    public interface ITaskRepository : IRepository<TTask>
    {
        Task<List<TTask>> GetCompletedTasksAsync();
    }
}
