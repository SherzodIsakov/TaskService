using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskService.Entities.Models;
using TaskService.Repositories.Entities;
using TaskService.Repositories.Interfaces;
using TaskService.Services.Interfaces;

namespace TaskService.Services.TextDapperService
{
    public class TaskDapperService : ITaskService
    {
        private readonly ITextTaskDapperRepository _textTaskDapperRepository;
        private readonly ITaskDapperRepository _taskDapperRepository;
        private readonly IMapper _mapper;

        public TaskDapperService(
            ITextTaskDapperRepository textTaskDapperRepository,
            ITaskDapperRepository taskDapperRepository,
            IMapper mapper)
        {
            _textTaskDapperRepository = textTaskDapperRepository;
            _taskDapperRepository = taskDapperRepository;
            _mapper = mapper;
        }

        #region TaskModel Постановка задачи
        public async Task<TaskModel> CreateTaskAsync(TaskModel taskModel)
        {
            var taskEntity = new TaskEntity
            {
                TaskStartTime = taskModel.TaskStartTime,
                TaskEndTime = taskModel.TaskEndTime,
                TaskInterval = taskModel.TaskInterval,
                FindEntities = taskModel.FindEntities
            };
            taskEntity = await _taskDapperRepository.CreateAsync(taskEntity);
            return _mapper.Map<TaskModel>(taskEntity);
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
        #endregion

        #region TextTaskModel Результат поиска
        public async Task<TextTaskModel> CreateTextTaskAsync(TextTaskModel textTaskModel)
        {
            var textTaskEntity = new TextTaskEntity
            {
                TaskId = textTaskModel.TaskId,
                TextId = textTaskModel.TextId,
                FindindWordsCount = textTaskModel.FindindWordsCount
            };
            textTaskEntity = await _textTaskDapperRepository.CreateAsync(textTaskEntity);
            return _mapper.Map<TextTaskModel>(textTaskEntity);
        }
        public async Task<TextTaskModel> GetTextTaskByIdAsync(Guid id)
        {
            var text = await _textTaskDapperRepository.GetByIdAsync(id);

            return _mapper.Map<TextTaskModel>(text);
        }
        public async Task<IEnumerable<TextTaskModel>> GetAllTextTasksAsync()
        {
            var text = await _textTaskDapperRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TextTaskEntity>, IEnumerable<TextTaskModel>>(text);

        }
        #endregion
    }
}