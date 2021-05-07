using Refit;
using System;
using System.IO;
using System.Threading.Tasks;
using TaskService.Entities.Models;

namespace TaskService.Client
{
    public interface ITaskClient
    {
        [Get("/text/{id}")]
        Task<TextTaskModel> GetTaskById(Guid id);
        [Get("/text/{id}")]
        Task<TextTaskModel> GetTextTaskById(Guid id);


        [Post("/text")]
        Task<TextTaskModel> Post(TaskModel taskModel);
        [Post("/text")]
        Task<TextTaskModel> Post(TextTaskModel textTaskModel);
    }
}
