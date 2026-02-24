namespace ProjectHub.Api.DTOs
{
    public class UpdateProjectDto
    {
        public required string Name { get; set; }
        public string? Desc { get; set; }
    }
}