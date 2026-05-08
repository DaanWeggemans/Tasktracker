using Microsoft.EntityFrameworkCore;
using Tasktracker.Domain.Entities;

namespace Tasktracker.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options) { }

        public DbSet<TTask> Tasks { get; set; }
    }
}
