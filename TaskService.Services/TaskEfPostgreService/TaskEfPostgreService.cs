//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using TaskService.Entities.Models;
//using TaskService.Repositories.Entities;
//using TaskService.Repositories.Interfaces;
//using TaskService.Services.Interfaces;

//namespace TaskService.Services.TaskEfService.TaskEfPostgreService
//{
//    public class TaskEfPostgreService : ITaskService
//    {
//        private readonly ITaskEfRepository _taskEfRepository;
//        private readonly IMapper _mapper;

//        public TaskEfPostgreService(
//            ITaskEfRepository taskEfRepository,
//            IMapper mapper)
//        {
//            _taskEfRepository = taskEfRepository;
//            _mapper = mapper;
//        }

//        public async Task<TaskModel> CreateTaskAsync(TaskModel taskModel)
//        {
//            var taskEntitys = _mapper.Map<IEnumerable<TaskSearchWordsEntity>>(taskModel.TaskSearchWordsModels);
//            var taskEntity = new TaskEntity
//            {
//                TaskStartTime = taskModel.TaskStartTime,
//                TaskEndTime = taskModel.TaskEndTime,
//                TaskInterval = taskModel.TaskInterval,
//                TaskSearchWordsEntities = taskEntitys
//            };
//            taskEntity = await _taskEfRepository.CreateAsync(taskEntity);

//            var findModels = _mapper.Map<IEnumerable<TaskSearchWordsModel>>(taskEntity.TaskSearchWordsEntities);
//            var taskModelresult = _mapper.Map<TaskModel>(taskEntity);
//            taskModelresult.TaskSearchWordsModels = findModels;

//            return taskModelresult;
//            // _mapper.Map<TaskModel>(taskEntity);
//        }
//        public async Task<TaskModel> GetTaskByIdAsync(Guid id)
//        {
//            var text = await _taskEfRepository.GetByIdAsync(id);

//            return _mapper.Map<TaskModel>(text);
//        }
//        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
//        {
//            var text = await _taskEfRepository.GetAllAsync();

//            return _mapper.Map<IEnumerable<TaskEntity>, IEnumerable<TaskModel>>(text);

//        }
//        public async Task<TaskModel> GetFirstTasksAsync()
//        {
//            var texts = await _taskEfRepository.GetAllAsync();

//            var text = texts.OrderBy(x => x.CreatedDate).FirstOrDefault();

//            return _mapper.Map<TaskEntity, TaskModel>(text);

//        }
//    }
//}
