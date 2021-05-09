using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskService.Entities.Models;
using TaskService.Repositories.Entities;
using TaskService.Repositories.Interfaces;
using TaskService.Services.Interfaces;

namespace TaskService.Services.TaskEfService
{
    public class TaskEfService : ITaskService
    {
        private readonly ITaskEfRepository _taskEfRepository;
        private readonly IMapper _mapper;

        public TaskEfService(
            ITaskEfRepository taskEfRepository,
            IMapper mapper)
        {
            _taskEfRepository = taskEfRepository;
            _mapper = mapper;
        }

        #region TaskModel Постановка задачи
        public async Task<TaskModel> CreateTaskAsync(TaskModel taskModel)
        {
            var taskEntitys = _mapper.Map<IEnumerable<FindEntity>>(taskModel.FindModels);
            var taskEntity = new TaskEntity
            {
                TaskStartTime = taskModel.TaskStartTime,
                TaskEndTime = taskModel.TaskEndTime,
                TaskInterval = taskModel.TaskInterval,
                FindEntities = taskEntitys
            };
            taskEntity = await _taskEfRepository.CreateAsync(taskEntity);

            var findModels = _mapper.Map<IEnumerable<FindModel>>(taskEntity.FindEntities);
            var taskModelresult = _mapper.Map<TaskModel>(taskEntity);
            taskModelresult.FindModels = findModels;

            return taskModelresult;
            // _mapper.Map<TaskModel>(taskEntity);
        }
        public async Task<TaskModel> GetTaskByIdAsync(Guid id)
        {
            var text = await _taskEfRepository.GetByIdAsync(id);

            return _mapper.Map<TaskModel>(text);
        }
        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            var text = await _taskEfRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TaskEntity>, IEnumerable<TaskModel>>(text);

        }
        public async Task<TaskModel> GetFirstTasksAsync()
        {
            var texts = await _taskEfRepository.GetAllAsync();

            var text = texts.OrderBy(x => x.CreatedDate).FirstOrDefault();

            return _mapper.Map<TaskEntity, TaskModel>(text);

        }
        #endregion

    }
}
