using System;
using System.Collections.Generic;
using System.Linq;
using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Models.Enums;

namespace HogwartsPotions.Data;

public class DbInitializer
{
    public static void Initialize(HogwartsContext context)
    {
        context.Database.EnsureCreated();

        // Look for any students.
        if (context.Students.Any())
        {
            return;   // DB has been seeded
        }

        var rooms = new Room[]
        {
            new Room{Capacity = 3},
            new Room{Capacity = 3},
            new Room{Capacity = 3},
            new Room{Capacity = 3}

        };

        foreach (Room r in rooms)
        {
            context.Rooms.Add(r);
        }
}