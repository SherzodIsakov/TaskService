using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TaskService.Repositories.Contexts;
using TaskService.Repositories.Entities;
using TaskService.Services.Models;

namespace TaskService.Services.TaskEfService
{
    public class TaskEfService : ITaskEfService
    {
        private readonly TaskContext _taskContext;
        private readonly IMapper _mapper;

        public TaskEfService(TaskContext taskContext, IMapper mapper)
        {
            _taskContext = taskContext;
            _mapper = mapper;
        }

        public async Task<TextTaskModel> CreateTask(TextTaskModel textTaskModel)
        {
            var textTask = _mapper.Map<TextTaskEntity>(textTaskModel);
            await _taskContext.TextTaskEntities.AddAsync(textTask);

            //var tasks = _taskContext.TextTaskEntities.FromSqlRaw($"SELECT * FROM TextTask WHERE id = @id", new { id = Guid.NewGuid() });
            //await _taskContext.SaveChangesAsync();

            return _mapper.Map<TextTaskModel>(textTask);
        }
    }
}
