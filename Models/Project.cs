namespace ProjectHub.Api.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Desc { get; set; } /* Optional */
        public required Guid OwnerId { get; set; }
        public ICollection<Guid> TasksIds { get; set; } = new List<Guid>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}