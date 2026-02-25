using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Api.DTOs
{
    public class UpdateProjectDto
    {
        [Required]
        public required string Name { get; set; }
        public string? Desc { get; set; }
    }
}