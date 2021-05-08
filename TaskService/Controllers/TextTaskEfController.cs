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
        private readonly ITextTaskService _taskService;
        private readonly ILogger<TextTaskEfController> _logger;

        public TextTaskEfController(ITextTaskService taskService, ILogger<TextTaskEfController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }
       
        [HttpGet("GetTextTaskById/{id}")]
        public async Task<ActionResult<TextTaskModel>> GetTextTaskById(Guid id)
        {
            var result = await _taskService.GetTextTaskByIdAsync(id);
            return result;
        }

        [HttpGet("GetAllTextTask")]
        public async Task<IEnumerable<TextTaskModel>> GetAllTextTask()
        {
            var result = await _taskService.GetAllTextTasksAsync();
            return result;
        }

        [HttpPost("textTask")]
        public async Task<ActionResult<TaskModel>> PostTextTask([FromForm]TextTaskModel textTaskModel)
        {
            var textFile = await _taskService.CreateTextTaskAsync(textTaskModel);
            return new OkObjectResult(textFile);
        }
    }
}
