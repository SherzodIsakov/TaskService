using Refit;
using System;
using System.IO;
using System.Threading.Tasks;
using TaskService.Services.Models;

namespace TaskService.Client
{
    public interface ITaskClient
    {
        [Get("/text/{id}")]
        Task<TextTaskModel> GetById(Guid id);
        [Post("/text")]
        Task<TextTaskModel> Post([Body] string text);
        [Post("/text/file/{streamTextFile}")]
        Task<TextTaskModel> PostFile(Stream streamTextFile);
        [Post("/text/url/{fileUrl}")]
        Task<TextTaskModel> PostFileUrl([Body] string fileUrl);
    }
}
