namespace ProjectHub.Api.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public ICollection<Guid> ProjectsIds { get; set; } = new List<Guid>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}