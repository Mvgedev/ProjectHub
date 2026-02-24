namespace ProjectHub.Api.DTOs
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public Guid OwnerId { get; set; }
        public ICollection<Guid> TasksIds { get; set; } = new List<Guid>();
        public DateTime CreatedAt { get; set; }
    }
}