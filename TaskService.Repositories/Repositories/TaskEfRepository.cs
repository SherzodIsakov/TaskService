using Microsoft.Extensions.Options;
using RepositoryBase.Repositories;
using TaskService.Repositories.Contexts;
using TaskService.Repositories.Entities;
using TaskService.Repositories.Interfaces;

namespace TaskService.Repositories.Repositories
{
    public class TaskEfRepository : BaseEfRepository<TaskEntity>, ITaskEfRepository
    {
        public TaskEfRepository(IOptions<TaskDbOption> dbOption, TaskContext textContext) : base(dbOption, textContext)
        {
        }
    }

}
