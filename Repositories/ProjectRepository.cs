using ProjectHub.Api.Models;

namespace ProjectHub.Api.Repositories {

	public class ProjectRepository : IProjectRepository
	{
		private ICollection<Project> Projects = new List<Project>();

		public Task<Project?> GetProjectByIdAsync(Guid id)
		{
			Project? proj = RetrieveProjectById(id);
			return Task.FromResult(proj);
		}

		public Task<IEnumerable<Project>> GetAllProjectsAsync(Guid userId)
		{
			IEnumerable<Project> ret = RetrieveUserProjects(userId);
			return Task.FromResult(ret);
		}

		public Task<Project> CreateProjectAsync(Project project)
		{
			Projects.Add(project);
			return Task.FromResult(project);
		}

		public Task<bool> UpdateProjectAsync(Project project)
		{
			Project? oldP = RetrieveProjectById(project.Id);
			if (oldP == null)
				return Task.FromResult(false);
			UpdateProject(oldP, project);
			return Task.FromResult(true);

		}

		public Task DeleteProjectAsync(Guid id)
		{
			Project? toDelete = RetrieveProjectById(id);
			if (toDelete != null)
			{
				Projects.Remove(toDelete);
			}
			return Task.CompletedTask;
		}

		private Project? RetrieveProjectById(Guid id)
		{
			return Projects.FirstOrDefault(p => p.Id == id);
		}

		private IEnumerable<Project> RetrieveUserProjects(Guid userId)
		{
			return Projects.Where(p => p.OwnerId == userId);
		}

		private void UpdateProject(Project oldP, Project newP)
		{
			oldP.Name = newP.Name;
			oldP.Desc = newP.Desc;
		}

	}
}