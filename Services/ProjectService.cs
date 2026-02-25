using ProjectHub.Api.DTOs;
using ProjectHub.Api.Models;
using ProjectHub.Api.Repositories;
using ProjectHub.Api.Exceptions;

namespace ProjectHub.Api.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectDto> GetProjectByIdAsync(Guid id, Guid userId)
        {
            Project? proj =  await _repository.GetProjectByIdAsync(id);
            if (proj == null)
                throw new KeyNotFoundException("Project not found");
            if (proj.OwnerId != userId)
                throw new UnauthorizedAccessException("Access Denied");
            ProjectDto ret = MappingProjectToDto(proj);
            return ret;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync(Guid userId)
        {
            IEnumerable<ProjectDto> ret =  RetrieveDtosFromProjects(await _repository.GetAllProjectsAsync(userId));
            return ret;
        }

        public async Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto, Guid userId)
        {
            Project proj = new Project
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Desc = dto.Desc,
                OwnerId = userId,
                CreatedAt = DateTime.UtcNow
            };
            Project result = await _repository.CreateProjectAsync(proj);
            return MappingProjectToDto(result);
        }

        public async Task UpdateProjectAsync(Guid projId, UpdateProjectDto dto, Guid userId)
        {
            Project? proj = await _repository.GetProjectByIdAsync(projId);
            if (proj == null)
                throw new KeyNotFoundException("Project not found");
            if (proj.OwnerId != userId)
                throw new UnauthorizedAccessException("Access Denied");

            proj.Name = dto.Name;
            proj.Desc = dto.Desc;

            bool updated = await _repository.UpdateProjectAsync(proj);

            if (!updated)
                throw new UpdateFailedException("Update failed");
        }

        public async Task DeleteProjectAsync(Guid id, Guid userId)
        {
            Project? proj = await _repository.GetProjectByIdAsync(id);
            if (proj == null)
                throw new KeyNotFoundException("Project not found");
            if (proj.OwnerId != userId)
                throw new UnauthorizedAccessException("Access Denied");
            bool deleted = await _repository.DeleteProjectAsync(id);
            if (!deleted)
                throw new DeleteFailedException("Delete failed");
                
        }

        private ProjectDto MappingProjectToDto(Project proj)
        {
            ProjectDto ret = new ProjectDto
            {
                Id = proj.Id,
                Name = proj.Name,
                Desc = proj.Desc ?? string.Empty,
                OwnerId = proj.OwnerId,
                TasksIds = proj.TasksIds ?? new List<Guid>(),
                CreatedAt = proj.CreatedAt
            };
            return ret;
        }

        private IEnumerable<ProjectDto> RetrieveDtosFromProjects(IEnumerable<Project> projs)
        {
           return projs.Select(p => MappingProjectToDto(p)).ToList();
        }
    }
}