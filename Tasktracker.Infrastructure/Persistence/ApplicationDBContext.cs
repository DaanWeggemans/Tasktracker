using Microsoft.EntityFrameworkCore;
using Tasktracker.Domain.Entities;

namespace Tasktracker.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options) { }

        public DbSet<TTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TTask>().HasData(
                new TTask()
                {
                    Id = new Guid("19C8B5FE-81B3-46C7-A06B-9577D33245BF"),
                    Title = "Create image.",
                    Description = "Creating an Docker image.",
                    IsDone = false,
                    CreatedAt = new DateTime(2026, 6, 5, 13, 0, 0)
                },
                new TTask()
                {
                    Id = new Guid("00177286-B887-4BF3-BDBA-315639370345"),
                    Title = "Download Docker.",
                    Description = "Downloading Docker.",
                    IsDone = true,
                    CreatedAt = new DateTime(2026, 6, 5, 11, 0, 0)
                },
                new TTask()
                {
                    Id = new Guid("4D152292-03BD-4D7C-890D-F1A27C4065FB"),
                    Title = "Create docker-compose.",
                    Description = "Creating a docker-compose.yml file.",
                    IsDone = false,
                    CreatedAt = new DateTime(2026, 6, 5, 15, 30, 0)
                }
            );

            base.OnModelCreating(builder);
        }
    }
}
