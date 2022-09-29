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

            if (!match)
            {
                var newIngredients = new List<Ingredient>
                {
                    await _context.Ingredients.FindAsync(potion.Ingredients[0].ID),
                    await _context.Ingredients.FindAsync(potion.Ingredients[1].ID),
                    await _context.Ingredients.FindAsync(potion.Ingredients[2].ID),
                    await _context.Ingredients.FindAsync(potion.Ingredients[3].ID),
                    await _context.Ingredients.FindAsync(potion.Ingredients[4].ID)

                };
                potion.Ingredients = newIngredients;
                potion.Recipe = new Recipe
                {
                    Ingredients = potion.Ingredients,
                    Student = potion.Student,
                    Name = $"{potion.Student.Name}'s discovery #{await _context.Recipes.CountAsync(r => r.Student.ID == potion.Student.ID) + 1}"
                };
                potion.Name =
                    $"{potion.Student.Name}'s discovery #{await _context.Recipes.CountAsync(r => r.Student.ID == potion.Student.ID) + 1}";
                potion.BrewingStatus = BrewingStatus.Discovery;
                foreach (var newPotionIngredient in potion.Ingredients)
                {
                    newPotionIngredient.Name = _context.Ingredients.First(i => i.ID == newPotionIngredient.ID).Name;
                }
                
            }
            
            potion = !_context.Potions.Contains(potion) ? _context.Potions.Add(potion).Entity : _context.Potions.Update(potion).Entity;

            
            await _context.SaveChangesAsync();
            return potion;
        }

        public async Task<Potion> BrewFreshPotion(Potion potion)
        {
            Potion newPotion = new Potion { Student = _context.Students.First(s => s.ID == potion.Student.ID) };
            var returnPotion = _context.Potions.Add(newPotion);
            await _context.SaveChangesAsync();
            return returnPotion.Entity;
        }

        public async Task<Potion> AddIngredient(long potionId, Ingredient ingredient)
        {
            var potion = GetPotion(potionId).Result;

            
            return potion;
        }

    }
}
