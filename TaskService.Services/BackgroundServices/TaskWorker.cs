using FindService.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskService.Entities.Models;
using TaskService.Services.Interfaces;

namespace TaskService.Services.BackgroundServices
{
    public class TaskWorker : BackgroundService
    {
        private readonly IFindClient _iFindClient;
        private readonly ITaskService _iTaskService;
        private readonly ITextTaskService _iTextTaskService;

        private readonly ILogger<TaskWorker> _logger;
        private int executionCount = 0;
        private Timer _timer;
        //Задача
        TaskModel GetTaskModel = null;
        public TaskWorker(IFindClient iFindClient, ITaskService iTaskService, ITextTaskService iTextTaskService, ILogger<TaskWorker> logger)
        {
            _iFindClient = iFindClient;
            _iTaskService = iTaskService;
            _iTextTaskService = iTextTaskService;
            _logger = logger;

            if (GetTaskModel is null)
            {
                GetOrCreateTaskAsync().Wait();
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
        public override Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            var timeSpan = GetTaskModel.TaskEndTime.Subtract(GetTaskModel.TaskStartTime);

            _timer = new Timer(DoWork, null, timeSpan, TimeSpan.FromMinutes(GetTaskModel.TaskInterval));

            return Task.CompletedTask;
        }
        public override Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        public override void Dispose()
        {
            _timer?.Dispose();
            GetTaskModel = null;
        }

        #region DoWork

       
        public void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount);
            _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);

            if (GetTaskModel is not null)
            {
                //Поиск новых файлов
                var allNewFiles = _iFindClient.GetAllTexts().Result.Where(x => DateTime.Now.Subtract(x.CreatedDate).Minutes >= GetTaskModel.TaskInterval);

                if (allNewFiles is not null && allNewFiles.Count() > 0)
                {
                    //Слова для поиска
                    string[] words = GetTaskModel.FindModels.Select(x => x.FindWord).ToArray();

                    foreach (var item in allNewFiles)
                    {
                        var findWords = _iFindClient.FindWords(item.Id, words).Result;

                        var textTaskModel = new TextTaskModel
                        {
                            TaskId = GetTaskModel.Id,
                            TextId = item.Id,
                            FindindWordsCount = findWords.Count(),
                        };

                        _iTextTaskService.CreateTextTaskAsync(textTaskModel).Wait();
                    }
                }                
            }
            else
            {
                //Получени данных для задачи
                GetOrCreateTaskAsync().Wait();
            }
        }

        //Если нет задач добавть новую задачу 
        private async Task GetOrCreateTaskAsync()
        { 
            //Слова по умолчанию если нет задачи в базе
            FindModel[] words = { new FindModel { FindWord = "Hello" }, new FindModel { FindWord = "World" } };

            GetTaskModel = await _iTaskService.GetFirstTasksAsync();
            if (GetTaskModel is null)
            {
                GetTaskModel = await AddNewTask(DateTime.Now, DateTime.Now.AddHours(2), 10, words);
            }
        }

        /// <summary>
        /// Постановка новой задачи
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="interval"></param>
        /// <param name="findWords"></param>
        /// <returns></returns>
        public async Task<TaskModel> AddNewTask(DateTime startDate, DateTime endDate, int interval, FindModel[] findWords)
        {
            var taskModel = new TaskModel
            {
                Id = new Guid(),
                TaskStartTime = startDate,
                TaskEndTime = endDate,
                TaskInterval = interval,
                FindModels = findWords
            };

            return await _iTaskService.CreateTaskAsync(taskModel);
        }

        /// <summary>
        /// Поиск слова во всех текстах
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TextService.Entities.Models.TextModel>> FindWords(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                return await _iFindClient.FindWord(word);

                //var textArray = word.Replace('\r', ' ').Replace('\n', ' ').Replace("  ", " ").Split(" ");
            }
            return null;
        }
        #endregion
    }
}
