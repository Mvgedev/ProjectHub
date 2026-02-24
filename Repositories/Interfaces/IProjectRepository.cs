using ProjectHub.Api.Models;

namespace ProjectHub.Api.Repositories
{
    public interface IProjectRepository
    {
        Task<Project?> GetProjectByIdAsync(Guid id);
        Task<IEnumerable<Project>> GetAllProjectsAsync(Guid userId);
        Task<Project> CreateProjectAsync(Project project);
        Task<bool> UpdateProjectAsync(Project project);
        Task<bool> DeleteProjectAsync(Guid id);
    }
}