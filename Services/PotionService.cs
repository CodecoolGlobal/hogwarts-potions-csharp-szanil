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

    }
}
