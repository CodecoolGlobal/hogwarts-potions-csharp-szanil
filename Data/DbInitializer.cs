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
        context.SaveChanges();

        var students = new Student[]
        {
            new Student{HouseType = HouseType.Gryffindor, Name = "Harry Potter", PetType = PetType.Owl, Room = rooms[0]},
            new Student{HouseType = HouseType.Gryffindor, Name = "Naville Longbottom", PetType = PetType.None, Room = rooms[0]},
            new Student{HouseType = HouseType.Gryffindor, Name = "Hermione Granger", PetType = PetType.Cat, Room = rooms[0]},
            new Student{HouseType = HouseType.Slytherin, Name = "Draco Malfoy", PetType = PetType.Owl, Room = rooms[1]},
            new Student{HouseType = HouseType.Slytherin, Name = "Vincent Crabbe", PetType = PetType.Owl, Room = rooms[1]},
            new Student{HouseType = HouseType.Slytherin, Name = "Gregory Goyle", PetType = PetType.Cat, Room = rooms[1]},
            new Student{HouseType = HouseType.Hufflepuff, Name = "Cathrine Ratbeater", PetType = PetType.Cat, Room = rooms[2]},
        };
        foreach (Student s in students)
        {
            context.Students.Add(s);
        }
        context.SaveChanges();
}