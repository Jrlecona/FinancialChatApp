namespace ChatApp.Application.DTOs;

public class ChatRoomDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<MessageDTO> Messages { get; set; }
    public List<UserDTO> Users { get; set; }
    public DateTime CreateAd { get; set; }
}