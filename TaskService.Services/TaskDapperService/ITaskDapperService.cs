using System;
using System.Threading.Tasks;
using TaskService.Services.Models;

namespace TaskService.Services.TextDapperService
{
    public interface ITaskDapperService
    {
        Task<TextTaskModel> AddFile(string text);
        Task<TextTaskModel> GetById(Guid id);
    }
}