using Microsoft.Extensions.DependencyInjection;
using Tasktracker.Application.Interfaces.Services;
using Tasktracker.Application.Services;

namespace Tasktracker.Application
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.RegisterServices();

            return services;
        }

        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
    }
}
