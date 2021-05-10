using FindService.Client.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Net.Http;
using TaskService.Repositories;
using TaskService.Repositories.Contexts;
using TaskService.Repositories.Interfaces;
using TaskService.Repositories.Repositories;
using TaskService.Repositories.Repositories.EfPostgreRepository;
using TaskService.Services.BackgroundServices;
using TaskService.Services.Interfaces;
using TaskService.Services.TaskDapperService;
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
            services.AddFindServiceClient(Configuration);

            services.AddAutoMapper(typeof(Startup));
            services.AddTransient(typeof(TaskContext));
            services.AddHostedService<TaskWorker>();

            #region Dapper
            //services.AddTransient<ITextTaskDapperRepository, TextTaskDapperRepository>();
            //services.AddTransient<ITaskDapperRepository, TaskDapperRepository>();

            //services.AddTransient<ITextTaskService, TextTaskDapperService>();
            //services.AddTransient<ITaskService, TaskDapperService>();
            #endregion

            #region Ef
            #region SQL
            //services.AddTransient<ITextTaskEfRepository, TextTaskEfRepository>();
            //services.AddTransient<ITaskEfRepository, TaskEfRepository>();
            #endregion

            #region Postgre
            services.AddTransient<ITextTaskEfRepository, TextTaskEfPostgreRepository>();
            services.AddTransient<ITaskEfRepository, TaskEfPostgreRepository>();
            #endregion

            services.AddTransient<ITextTaskService, TextTaskEfService>();           
            services.AddTransient<ITaskService, TaskEfService>();
            #endregion
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
