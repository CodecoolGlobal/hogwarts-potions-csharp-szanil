using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Models.Enums;
using HogwartsPotions.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsPotions.Services
{
    public class PotionService : IPotionService
    {
        private readonly HogwartsContext _context;

        public PotionService(HogwartsContext context)
        {
            _context = context;
        }

        public async Task<List<Potion>> GetAllPotions()
        {
            return await _context.Potions
                .Include(p => p.Student)
                .Include(p => p.Ingredients)
                .Include(p => p.Recipe.Student)
                .Include(p => p.Recipe.Ingredients)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Potion>> GetPotionByStudentId(long studentId)
        {
            return await _context.Potions
                .Include(p => p.Student)
                .Include(p => p.Ingredients)
                .Include(p => p.Recipe.Student)
                .Include(p => p.Recipe.Ingredients)
                .Where(p => p.Student.ID == studentId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Potion> BrewingPotion(Potion potion)
        {
            if (!_context.Potions.Contains(potion))
            {
                potion = new Potion{Student = _context.Students.First(s => s.ID == potion.Student.ID), Ingredients = potion.Ingredients.OrderBy(i => i.ID).ToList() };
            }
            

            bool match = false;
            int recipeIndex = 0;
            var allRecipe = GetAllRecipe().Result;

            foreach (var recipe in allRecipe)
            {
                if (recipe.Ingredients.Select(i => i.ID).ToList().SequenceEqual(potion.Ingredients.Select(i => i.ID).ToList()))
                {
                    match = true;
                    var sameRecipe = allRecipe[recipeIndex];
                    potion.Ingredients = sameRecipe.Ingredients;
                    potion.Recipe = sameRecipe;
                    potion.Name = $"{sameRecipe.Name}";
                    potion.BrewingStatus = BrewingStatus.Replica;
                    break;
                }
                recipeIndex++;
            }
            
            potion = !_context.Potions.Contains(potion) ? _context.Potions.Add(potion).Entity : _context.Potions.Update(potion).Entity;

            
            await _context.SaveChangesAsync();
            return potion;
        }
    }
}
