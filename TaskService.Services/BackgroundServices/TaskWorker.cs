using FindService.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskService.Entities.Models;
using TaskService.Services.Interfaces;
using TextService.Entities.Models;

namespace TaskService.Services.BackgroundServices
{
    public class TaskWorker : BackgroundService
    {
        private readonly IFindClient _iFindClient;
        private readonly ITaskService _iTaskService;
        private readonly ITextTaskService _iTextTaskService;

        private readonly ILogger<TaskWorker> _logger;
        private Timer _timer;

        //Задача из базы
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
                var timeSpan = GetTaskModel.TaskEndTime.Subtract(GetTaskModel.TaskStartTime);
                await Task.Delay(timeSpan, stoppingToken);
            }
        }
        public override Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(GetTaskModel.TaskInterval));

            return Task.CompletedTask;
        }
        public override Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        public override void Dispose()
        {
            _timer?.Dispose();
            GetTaskModel = null;
        }

        #region DoWork       
        private void DoWork(object state)
        {
            try
            {
                if (GetTaskModel is not null)
                {
                    //Поиск новых файлов
                    var allFiles = _iFindClient.GetAllTexts().Result;
                    var allNewFiles = allFiles.Where(x => DateTime.Now.Subtract(x.CreatedDate).Minutes >= GetTaskModel.TaskInterval).ToList();
                    var qwe = allNewFiles.Count();


                    if (allNewFiles is not null && allNewFiles.Count() > 0)
                    {
                        //Слова для поиска
                        string[] words = GetTaskModel.TaskSearchWords.Split(" ");

                        foreach (var item in allNewFiles)
                        {
                            var textArray = item.Text.Replace('\r', ' ').Replace('\n', ' ').Replace("  ", " ").Split(" ");
                            var findWords = textArray.SelectMany(e => words.Where(x => x == e));

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
            catch (Exception ex)
            {

                throw;
            }
        }

        //Если нет задач добавляем новую 
        private async Task GetOrCreateTaskAsync()
        {
            //Слова по умолчанию если нет задачи в базе
            string words = "Hello World";

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
        public async Task<TaskModel> AddNewTask(DateTime startDate, DateTime endDate, int interval, string findWords)
        {
            var taskModel = new TaskModel
            {
                Id = new Guid(),
                TaskStartTime = startDate,
                TaskEndTime = endDate,
                TaskInterval = interval,
                TaskSearchWords = findWords
            };

            return await _iTaskService.CreateTaskAsync(taskModel);
        }

        /// <summary>
        /// Поиск слова во всех текстах
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TextModel>> FindWords(string word)
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
