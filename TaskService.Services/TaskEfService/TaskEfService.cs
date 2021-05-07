using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskService.Entities.Models;
using TaskService.Repositories.Entities;
using TaskService.Repositories.Interfaces;
using TaskService.Services.Interfaces;

namespace TaskService.Services.TaskEfService
{
    public class TaskEfService : ITaskService
    {
        private readonly ITextTaskEfRepository _textTaskEfRepository;
        private readonly ITaskEfRepository _taskEfRepository;
        private readonly IMapper _mapper;

        public TaskEfService(
            ITextTaskEfRepository textTaskEfRepository,
            ITaskEfRepository taskEfRepository,
            IMapper mapper)
        {
            _textTaskEfRepository = textTaskEfRepository;
            _taskEfRepository = taskEfRepository;
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
            taskEntity = await _taskEfRepository.CreateAsync(taskEntity);
            return _mapper.Map<TaskModel>(taskEntity);
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
            textTaskEntity = await _textTaskEfRepository.CreateAsync(textTaskEntity);
            return _mapper.Map<TextTaskModel>(textTaskEntity);
        }
        public async Task<TextTaskModel> GetTextTaskByIdAsync(Guid id)
        {
            var text = await _textTaskEfRepository.GetByIdAsync(id);

            return _mapper.Map<TextTaskModel>(text);
        }
        public async Task<IEnumerable<TextTaskModel>> GetAllTextTasksAsync()
        {
            var text = await _textTaskEfRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TextTaskEntity>, IEnumerable<TextTaskModel>>(text);

        }
        #endregion
    }
}
