using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApp.Application.DTOs;
using ChatApp.Application.Interfaces;
using ChatApp.Application.Services;
using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ChatApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IUserService _userService;

        public ChatController(IChatService chatService, IUserService userService)
        {
            _chatService = chatService;
            _userService = userService;
        }

        [HttpGet("chatrooms")]
        public async Task<ActionResult<IEnumerable<ChatRoomDTO>>> GetChatRooms()
        {
            var chatRooms = await _chatService.GetChatRoomsAsync();
            return Ok(chatRooms);
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{roomId}/messages")]
        public async Task<ActionResult<IEnumerable<MessageDTO>>> GetMessages(Guid roomId)
        {
            var messages = await _chatService.GetLast50MessagesAsync(roomId);
            return Ok(messages);
        }

        [HttpPost("{roomId}/messages")]
        public async Task<IActionResult> SendMessage(Guid roomId, [FromBody] MessageDTO messageDto)
        {
            await _chatService.AddMessageAsync(messageDto.SenderId, roomId, messageDto.Text);
            return Ok();
        }
    }
}