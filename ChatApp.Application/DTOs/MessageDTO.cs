namespace ChatApp.Application.DTOs;

public class MessageDTO
{
    public Guid Id { get; set; }
    public Guid SenderId { get; set; }
    public string Text { get; set; }
    public DateTime SentAt { get; set; }
}