using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskService.Entities.Models;
using TaskService.Repositories.Entities;
using TaskService.Repositories.Interfaces;
using TaskService.Services.Interfaces;

namespace TaskService.Services.TextDapperService
{
    public class TaskDapperService : ITaskService
    {
        private readonly ITaskDapperRepository _taskDapperRepository;
        private readonly IMapper _mapper;

        public TaskDapperService(
            ITaskDapperRepository taskDapperRepository,
            IMapper mapper)
        {
            _taskDapperRepository = taskDapperRepository;
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
            taskEntity = await _taskDapperRepository.CreateAsync(taskEntity);

            var findModels = _mapper.Map<IEnumerable<FindModel>>(taskEntity.FindEntities);
            var taskModelresult = _mapper.Map<TaskModel>(taskEntity);
            taskModelresult.FindModels = findModels;

            return taskModelresult;
            // _mapper.Map<TaskModel>(taskEntity);
        }
        public async Task<TaskModel> GetTaskByIdAsync(Guid id)
        {
            var text = await _taskDapperRepository.GetByIdAsync(id);

            return _mapper.Map<TaskModel>(text);
        }
        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            var text = await _taskDapperRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TaskEntity>, IEnumerable<TaskModel>>(text);

        }
        public async Task<TaskModel> GetFirstTasksAsync()
        {
            var texts = await _taskDapperRepository.GetAllAsync();

            var text = texts.OrderBy(x => x.CreatedDate).FirstOrDefault();

            return _mapper.Map<TaskEntity, TaskModel>(text);

        }
        #endregion       
    }
}