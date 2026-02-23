using ProjectHub.Api.Models;

namespace ProjectHub.Api.Repositories
{
    public interface ITaskItemRepository
    {
        Task<TaskItem> GetTaskItemByIdAsync(Guid id);
        Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(Guid projectId);
        Task<TaskItem> CreateTaskAsync(TaskItem task);
        Task UpdateTaskItem(TaskItem task);
        Task DeleteTaskItem(Guid id);
    }
}