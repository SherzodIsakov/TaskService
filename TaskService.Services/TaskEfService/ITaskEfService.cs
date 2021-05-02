using System.Threading.Tasks;
using TaskService.Services.Models;

namespace TaskService.Services.TaskEfService
{
    public interface ITaskEfService
    {
        Task<TextTaskModel> CreateTask(TextTaskModel textTaskModel);
    }
}
