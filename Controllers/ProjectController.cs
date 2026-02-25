using ProjectHub.Api.Services;
using ProjectHub.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ProjectHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjects()
        {
            var userId = GetUserId();

            var projects = await _service.GetAllProjectsAsync(userId);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(Guid id)
        {
            var userId = GetUserId();

            var project = await _service.GetProjectByIdAsync(id, userId);
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject([FromBody] CreateProjectDto dto)
        {
            var userId = GetUserId();

            var rDto = await _service.CreateProjectAsync(dto, userId);
            return CreatedAtAction(
                nameof(GetProjectById),
                new { id = rDto.Id },
                rDto
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] UpdateProjectDto dto)
        {
            var userId = GetUserId();

            await _service.UpdateProjectAsync(id, dto, userId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var userId = GetUserId();

            await _service.DeleteProjectAsync(id, userId);
            return NoContent();

        }

        private Guid GetUserId()
        {
            var claim = HttpContext.User.FindFirst("userId");
            if (claim == null || !Guid.TryParse(claim.Value, out Guid userId))
                throw new UnauthorizedAccessException("User not authenticated");

            return userId;
        }
    }
}