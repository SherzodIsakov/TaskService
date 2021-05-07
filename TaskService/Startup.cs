using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TaskService.Repositories;
using TaskService.Repositories.Contexts;
using TaskService.Repositories.Interfaces;
using TaskService.Repositories.Repositories;
using TaskService.Services.Interfaces;
using TaskService.Services.TaskEfService;
using TaskService.Services.TextDapperService;

namespace TaskService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskService", Version = "v1" });
            });

            services.AddTaskDbOption(Configuration);
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient(typeof(TaskContext));

            services.AddTransient<ITextTaskDapperRepository, TextTaskDapperRepository>();
            services.AddTransient<ITextTaskEfRepository, TextTaskEfRepository>();
            services.AddTransient<ITaskDapperRepository, TaskDapperRepository>();
            services.AddTransient<ITaskEfRepository, TaskEfRepository>();

            services.AddTransient<ITaskService, TaskDapperService>();
            services.AddTransient<ITaskService, TaskEfService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
