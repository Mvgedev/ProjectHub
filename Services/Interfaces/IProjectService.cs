using ProjectHub.Api.DTOs;

namespace ProjectHub.Api.Services
{
    public interface IProjectService
    {
        Task<ProjectDto> GetProjectByIdAsync(Guid id);
        Task<IEnumerable<ProjectDto>> GetAllProjectsAsync(Guid userId);
        Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto, Guid userId);
        Task UpdateProjectAsync(ProjectDto dto);
        Task DeleteProjectAsync(Guid id);
    }
}