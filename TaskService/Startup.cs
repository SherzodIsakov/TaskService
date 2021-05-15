using AuthenticationBase.Extensions;
using FindService.Client.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TaskService.Repositories;
using TaskService.Repositories.Contexts;
using TaskService.Repositories.Interfaces;
using TaskService.Repositories.Repositories.EfPostgreRepository;
using TaskService.Services.BackgroundServices;
using TaskService.Services.Interfaces;
using TaskService.Services.TaskEfService;

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
            services.AddAppAuthentication(Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskService", Version = "v1" });
            });
           
            services.AddFindServiceClient(Configuration);
            services.AddAutoMapper(typeof(Startup));            
            services.AddHostedService<TaskWorker>();

            #region Dapper
            //services.AddTransient<ITextTaskDapperRepository, TextTaskDapperRepository>();
            //services.AddTransient<ITaskDapperRepository, TaskDapperRepository>();

            //services.AddTransient<ITextTaskService, TextTaskDapperService>();
            //services.AddTransient<ITaskService, TaskDapperService>();
            #endregion

            #region Ef
            #region SQL
            //services.AddSqlTaskDbOption(Configuration);
            //services.AddTransient(typeof(TaskContext));
            //services.AddTransient<ITextTaskEfRepository, TextTaskEfRepository>();
            //services.AddTransient<ITaskEfRepository, TaskEfRepository>();
            #endregion

            #region Postgre
            services.AddPostgreTaskDbOption(Configuration);
            services.AddTransient(typeof(TaskPostgreContext));
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
