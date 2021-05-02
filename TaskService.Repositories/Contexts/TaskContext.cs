using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskService.Repositories.Entities;

namespace TaskService.Repositories.Contexts
{
    public class TaskContext : DbContext
    {
        private readonly IOptions<TaskDbOption> _taskDbOptions;
        public DbSet<TextTaskEntity>  TextTaskEntities { get; set; }

        public TaskContext(IOptions<TaskDbOption> taskDbOptions)
        {
            _taskDbOptions = taskDbOptions;
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_taskDbOptions.Value.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<FindEntity>().Ignore(s => s.FindValue);
            //modelBuilder.Entity<TextTask>().Property(t => t.TaskType).HasColumnName("task_type");
            //modelBuilder.Entity<TextTask>().HasAlternateKey(t => new { t.Name, t.StartTime });
            //modelBuilder.Ignore<TaskType>();
        }
    }
}
