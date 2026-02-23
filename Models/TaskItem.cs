namespace ProjectHub.Api.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}