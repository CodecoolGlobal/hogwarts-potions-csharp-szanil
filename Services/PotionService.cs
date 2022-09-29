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
    }
}
