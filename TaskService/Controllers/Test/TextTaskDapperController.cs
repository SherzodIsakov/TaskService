//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using TaskService.Entities.Models;
//using TaskService.Services.Interfaces;

//namespace TaskService.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TextTaskDapperController : ControllerBase
//    {
//        private readonly ITextTaskService _textTaskService;
//        private readonly ILogger<TextTaskDapperController> _logger;

//        public TextTaskDapperController(ITextTaskService textTaskService, ILogger<TextTaskDapperController> logger)
//        {
//            _textTaskService = textTaskService;
//            _logger = logger;
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<TextTaskModel>> GetTextTaskById(Guid id)
//        {
//            var result = await _textTaskService.GetTextTaskByIdAsync(id);
//            return result;
//        }

//        [HttpGet]
//        public async Task<IEnumerable<TextTaskModel>> GetAllTextTask()
//        {
//            var result = await _textTaskService.GetAllTextTasksAsync();
//            return result;
//        }

//        [HttpPost]
//        public async Task<ActionResult<TaskModel>> Post(TextTaskModel textTaskModel)
//        {
//            var textFile = await _textTaskService.CreateTextTaskAsync(textTaskModel);
//            return new OkObjectResult(textFile);
//        }
//    }
//}
