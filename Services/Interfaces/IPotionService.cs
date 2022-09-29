using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models.Entities;

namespace HogwartsPotions.Services.Interfaces
{
    public interface IPotionService
    {
        Task<List<Potion>> GetAllPotions();
        Task<List<Potion>> GetPotionByStudentId(long studentId);
        Task<Potion> BrewingPotion(Potion potion);
        Task<Potion> BrewFreshPotion(Potion potion);
        Task<Potion> AddIngredient(long potionId, Ingredient ingredient);
        Task<List<Recipe>> SimilarRecipes(long potionId);
        Task<Potion> GetPotion(long potionId);
        Task<List<Recipe>> GetAllRecipe();
    }
}
