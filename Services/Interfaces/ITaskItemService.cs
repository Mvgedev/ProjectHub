using ProjectHub.Api.DTOs;

namespace ProjectHub.Api.Services
{
    public interface ITaskItemService
    {
        Task<TaskItemDto> GetTaskItemByIdAsync(Guid id);
        Task<IEnumerable<TaskItemDto>> GetTasksByProjectAsync(Guid projectId);
        Task<TaskItemDto> CreateTaskAsync(CreateTaskItemDto dto);
        Task UpdateTaskItemAsync(TaskItemDto dto);
        Task DeleteTaskItemAsync(Guid id);
    }
}