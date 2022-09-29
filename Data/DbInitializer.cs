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

        var ingredients = new Ingredient[]
        {
            new Ingredient{Name = "Abraxan hair"},
            new Ingredient{Name = "Aconite"},
            new Ingredient{Name = "Balm"},
            new Ingredient{Name = "Banana"},
            new Ingredient{Name = "Cat Hair"},
            new Ingredient{Name = "Cheese"},
            new Ingredient{Name = "Dandruff"},
            new Ingredient{Name = "Doxy egg"},
            new Ingredient{Name = "Eagle Owl Feather"},
            new Ingredient{Name = "Exploding Ginger Eyelash"},
            new Ingredient{Name = "Firefly"},
            new Ingredient{Name = "Foxglove"},
            new Ingredient{Name = "Ginger"},
            new Ingredient{Name = "Granian hair"},
            new Ingredient{Name = "Honey"},
            new Ingredient{Name = "Horse hair"},
            new Ingredient{Name = "Iguana blood"},
            new Ingredient{Name = "Infusion of Wormwood"},
            new Ingredient{Name = "Jewelweed"},
            new Ingredient{Name = "Jobberknoll feather"},
            new Ingredient{Name = "Kelp"},
            new Ingredient{Name = "Knotgrass"},
            new Ingredient{Name = "Lacewing Fly"},
            new Ingredient{Name = "Lard"},
            new Ingredient{Name = "Mandrake"},
            new Ingredient{Name = "Morning dew"},
            new Ingredient{Name = "Neem oil"},
            new Ingredient{Name = "Niffler's Fancy"},
            new Ingredient{Name = "Occamy egg"},
            new Ingredient{Name = "Onion juice"},
            new Ingredient{Name = "Pickled Slugs"},
            new Ingredient{Name = "Ptolemy"},
            new Ingredient{Name = "Rose"},
            new Ingredient{Name = "Russian's Dragon Nails"},
            new Ingredient{Name = "Saltpetre"},
            new Ingredient{Name = "Shrivelfig"},
            new Ingredient{Name = "Thaumatagoria"},
            new Ingredient{Name = "Tormentil"},
            new Ingredient{Name = "Urine"},
            new Ingredient{Name = "Unicorn Hair"},
            new Ingredient{Name = "Valerian"},
            new Ingredient{Name = "Vervain infusion"},
            new Ingredient{Name = "Wiggenbush"},
            new Ingredient{Name = "Wool of Bat"},

        };
        foreach (Ingredient i in ingredients)
        {
            context.Ingredients.Add(i);
        }
        context.SaveChanges();

}