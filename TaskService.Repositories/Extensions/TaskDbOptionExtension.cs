using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaskService.Repositories
{
    public static class TaskDbOptionExtension
    {
        public static void AddTaskDbOption(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TaskDbOption>(options =>
                options.ConnectionString = configuration.GetConnectionString("Default"));
        }
    }
}