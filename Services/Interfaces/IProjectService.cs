using ProjectHub.Api.DTOs;

namespace ProjectHub.Api.Services
{
    public interface IProjectService
    {
        Task<ProjectDto> GetProjectByIdAsync(Guid id);
        Task<IEnumerable<ProjectDto>> GetAllProjectsAsync(Guid userId);
        Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto, Guid userId);
        Task UpdateProjectAsync(Guid projId, UpdateProjectDto dto);
        Task DeleteProjectAsync(Guid id);
    }
}