using Refit;
using System;
using System.IO;
using System.Threading.Tasks;
using TaskService.Entities.Models;

namespace TaskService.Client
{
    public interface ITaskClient
    {
        [Get("/api/taskservice/{id}")]
        Task<TaskModel> GetTaskById(Guid id);

        [Get("/api/taskservice")]
        Task<TaskModel> GetAllTask();

        [Post("/api/taskservice/task")]
        Task<TaskModel> Post(TaskModel taskModel);


        [Get("/api/texttaskservice/{id}")]
        Task<TextTaskModel> GetTextTaskById(Guid id);
       
        [Get("/api/texttaskservice")]
        Task<TextTaskModel> GetAllTextTask();
       
        [Post("/api/texttaskservice/texttask")]
        Task<TextTaskModel> Post(TextTaskModel textTaskModel);
    }
}
