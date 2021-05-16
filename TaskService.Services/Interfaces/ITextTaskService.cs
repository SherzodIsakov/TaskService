using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskService.Entities.Models;

namespace TaskService.Services.Interfaces
{
    /// <summary>
    /// Результат выполнения задачи 
    /// </summary>
    public interface ITextTaskService
    {
        Task<TextTaskModel> CreateTextTaskAsync(TextTaskModel textTaskModel);
        Task<TextTaskModel> GetTextTaskByIdAsync(Guid id);
        Task<IEnumerable<TextTaskModel>> GetAllTextTasksAsync(); //string token
    }
}
