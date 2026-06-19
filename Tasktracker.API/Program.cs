using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Tasktracker.Application;
using Tasktracker.Infrastructure;
using Tasktracker.Infrastructure.Persistence;

namespace Tasktracker.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.RegisterApplication();
            builder.Services.RegisterInfrastructure(builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("api", new OpenApiInfo()
                {
                    Title = "API",
                    Version = null
                });
            });

            builder.Services.AddCors(options =>
                options.AddDefaultPolicy(option =>
                {
                    option.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                }));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
                context.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(options =>
                {
                    options.RouteTemplate = "{documentName}/specifications.json";
                });

                app.UseSwaggerUI(options =>
                {
                    options.RoutePrefix = "api";
                    options.SwaggerEndpoint("specifications.json", "API");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors();


            app.MapControllers();
            app.MapGet("/", (HttpContext context) =>
            {
                context.Response.Redirect("/api");
                return Task.CompletedTask;
            });

            app.Run();
        }
    }
}
