using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskService.Entities.Models;
using TaskService.Services.Interfaces;

namespace TaskService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextTaskEfController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TextTaskEfController> _logger;

        public TextTaskEfController(ITaskService taskService, ILogger<TextTaskEfController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(Guid id)
        {
            var result = await _taskService.GetTaskByIdAsync(id);
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskModel>> GetAllTask()
        {
            var result = await _taskService.GetAllTasksAsync();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Post(TaskModel taskModel)
        {
            var textFile = await _taskService.CreateTaskAsync(taskModel);
            return new OkObjectResult(textFile);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<TextTaskModel>> GetTextTaskById(Guid id)
        {
            var result = await _taskService.GetTextTaskByIdAsync(id);
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<TextTaskModel>> GetAllTextTask()
        {
            var result = await _taskService.GetAllTextTasksAsync();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Post(TextTaskModel textTaskModel)
        {
            var textFile = await _taskService.CreateTextTaskAsync(textTaskModel);
            return new OkObjectResult(textFile);
        }
    }
}
