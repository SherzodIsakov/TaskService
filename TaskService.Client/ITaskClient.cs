using Refit;
using System;
using System.IO;
using System.Threading.Tasks;
using TaskService.Entities.Models;

namespace TaskService.Client
{
    public interface ITaskClient
    {
        [Get("/text/GetTaskById/{id}")]
        Task<TextTaskModel> GetTaskById(Guid id);
        [Get("/text/GetTextTaskById/{id}")]
        Task<TextTaskModel> GetTextTaskById(Guid id);

        [Get("/text/GetAllTask")]
        Task<TextTaskModel> GetAllTask();
        [Get("/text/GetAllTextTask")]
        Task<TextTaskModel> GetAllTextTask();

        [Post("/text/task")]
        Task<TextTaskModel> Post(TaskModel taskModel);
        [Post("/text/textTask")]
        Task<TextTaskModel> Post(TextTaskModel textTaskModel);
    }
}
