using Refit;
using System;
using System.IO;
using System.Threading.Tasks;
using TaskService.Entities.Models;

namespace TaskService.Client
{
    public interface ITaskClient
    {
        [Get("/taskservice/GetTaskById/{id}")]
        Task<TaskModel> GetTaskById(Guid id);

        [Get("/taskservice/GetAllTask")]
        Task<TaskModel> GetAllTask();

        [Post("/taskservice/task")]
        Task<TaskModel> Post(TaskModel taskModel);


        [Get("/texttaskservice/GetTextTaskById/{id}")]
        Task<TextTaskModel> GetTextTaskById(Guid id);
       
        [Get("/texttaskservice/GetAllTextTask")]
        Task<TextTaskModel> GetAllTextTask();
       
        [Post("/texttaskservice/TextTask")]
        Task<TextTaskModel> Post(TextTaskModel textTaskModel);
    }
}
