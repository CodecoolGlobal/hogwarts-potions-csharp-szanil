using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsPotions.Controllers
{
    [ApiController, Route("/room")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<List<Room>> GetAllRooms()
        {
            return await _roomService.GetAllRooms();
        }

        [HttpPost]
        public async Task AddRoom([FromBody] Room room)
        {
            await _roomService.AddRoom(room);
        }

        [HttpGet("{id}")]
        public async Task<Room> GetRoomById([FromRoute] long id)
        {
            return await _roomService.GetRoom(id);
        }

        [HttpPut("{id}")]
        public async Task UpdateRoomById([FromRoute] long id, [FromBody] Room updatedRoom)
        {
            await _roomService.UpdateRoom(id, updatedRoom);
        }

        [HttpDelete("{id}")]
        public async Task DeleteRoomById([FromRoute] long id)
        {
            await _roomService.DeleteRoom(id);
        }

        [HttpGet("rat-owners")]
        public async Task<List<Room>> GetRoomsForRatOwners()
        {
            return await _roomService.GetRoomsForRatOwners();
        }
    }
}
