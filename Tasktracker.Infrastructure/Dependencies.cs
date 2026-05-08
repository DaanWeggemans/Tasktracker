using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tasktracker.Application.Interfaces.Repositories;
using Tasktracker.Infrastructure.Persistence;
using Tasktracker.Infrastructure.Repositories;

namespace Tasktracker.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDatabase(configuration);
            services.RegisterRepositories();

            return services;
        }

        private static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), database =>
                {
                    database.MigrationsHistoryTable("Migrations");
                });
            });

            return services;
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
