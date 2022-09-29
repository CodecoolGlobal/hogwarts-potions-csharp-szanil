using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Models.Enums;
using HogwartsPotions.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Services;

public class RoomService : IRoomService
{
    private readonly HogwartsContext _context;

    public RoomService(HogwartsContext context)
    {
        _context = context;
    }

    public async Task AddRoom(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
    }

    public async Task<Room> GetRoom(long roomId)
    {
        return await _context.Rooms.Include(r => r.Residents).FirstOrDefaultAsync(r => r.ID == roomId);
    }

    public async Task<List<Room>> GetAllRooms()
    {
        return await _context.Rooms.Include(r => r.Residents).AsNoTracking().ToListAsync();
    }

}