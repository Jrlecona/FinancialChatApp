using ChatApp.Domain.Entities;
using ChatApp.Domain.Interfaces;
using ChatApp.Infrastructure.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Infrastructure.Repositories
{
    public class ChatRoomRepository : IChatRoomRepository
    {
        private readonly DbSet<ChatRoom> _chatRooms;

        public ChatRoomRepository(ApplicationDbContext dbContext)
        {
            _chatRooms = dbContext.ChatRooms;
        }

        public async Task<IEnumerable<ChatRoom>> GetAllAsync()
        {
            return await _chatRooms.ToListAsync();
        }

        public async Task<ChatRoom> GetByIdAsync(Guid id)
        {
            return await _chatRooms.FindAsync(id);
        }

        public async Task AddAsync(ChatRoom chatRoom)
        {
            await _chatRooms.AddAsync(chatRoom);
        }

        public Task UpdateAsync(ChatRoom chatRoom)
        {
            _chatRooms.Update(chatRoom);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var chatRoom = await GetByIdAsync(id);
            _chatRooms.Remove(chatRoom);
        }
    }
}
