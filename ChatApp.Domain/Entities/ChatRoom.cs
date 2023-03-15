namespace ChatApp.Domain.Entities;

public class ChatRoom
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Message> Messages { get; set; } = new();
    public List<User> Users { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}