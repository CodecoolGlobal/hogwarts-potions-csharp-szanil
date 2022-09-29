﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models.Entities;

namespace HogwartsPotions.Services.Interfaces;

public interface IRoomService
{
    Task AddRoom(Room room);
    Task<Room> GetRoom(long roomId);
    Task<List<Room>> GetAllRooms();
    Task UpdateRoom(long id, Room room);
    Task DeleteRoom(long id);
    Task<List<Room>> GetRoomsForRatOwners();
}