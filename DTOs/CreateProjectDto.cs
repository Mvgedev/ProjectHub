namespace ProjectHub.Api.DTOs
{
	public class CreateProjectDto
	{
		public required string Name { get; set; }
		public string? Desc { get; set; }
	}
}