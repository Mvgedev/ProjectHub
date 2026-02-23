namespace ProjectHub.Api.DTOs
{
    public class CreateTaskItemDto
    {
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
        public Guid ProjectId { get; set; } /* On veut pouvoir créer une Task depuis la home page pour X projet */
    }
}