namespace ProjectHub.Api.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Guid> ProjectsId { get; set; } = new List<Guid>();
        public DateTime CreatedAt { get; set; }
    }
}