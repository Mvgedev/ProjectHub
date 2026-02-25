using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Api.DTOs
{
	public class CreateProjectDto
	{
		[Required]
		public required string Name { get; set; }
		public string? Desc { get; set; }
	}
}