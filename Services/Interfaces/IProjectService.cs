using ProjectHub.Api.DTOs;

namespace ProjectHub.Api.Services
{
    public interface IProjectService
    {
        Task<ProjectDto> GetProjectByIdAsync(Guid id, Guid userId);
        Task<IEnumerable<ProjectDto>> GetAllProjectsAsync(Guid userId);
        Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto, Guid userId);
        Task UpdateProjectAsync(Guid projId, UpdateProjectDto dto, Guid userId);
        Task DeleteProjectAsync(Guid id, Guid userId);
    }
}