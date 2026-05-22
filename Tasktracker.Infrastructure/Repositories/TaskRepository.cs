using Microsoft.EntityFrameworkCore;
using Tasktracker.Application.Interfaces.Repositories;
using Tasktracker.Domain.Entities;
using Tasktracker.Infrastructure.Persistence;

namespace Tasktracker.Infrastructure.Repositories
{
    public class TaskRepository : Repository<TTask>, ITaskRepository
    {
        private readonly ApplicationDBContext Context;

        public TaskRepository(ApplicationDBContext context)
            : base(context)
        {
            Context = context;
        }

        public async Task<List<TTask>> GetCompletedTasksAsync()
            => await Context.Tasks
                .Where(task => task.IsDone)
                .ToListAsync();
    }
}
