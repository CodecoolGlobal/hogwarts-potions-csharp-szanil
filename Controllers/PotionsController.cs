﻿using HogwartsPotions.Models.Entities;
using HogwartsPotions.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HogwartsPotions.Controllers
{
    [ApiController, Route("/potions")]
    public class PotionsController : Controller
    {
        private readonly IPotionService _potionService;

        public PotionsController(IPotionService potionService)
        {
            _potionService = potionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPotions()
        {
            return Ok(await _potionService.GetAllPotions());
        }

        [HttpGet]
        [Route("{studentId}")]
        public async Task<IActionResult> GetPotionByStudentId([FromRoute] long studentId)
        {
            return Ok(await _potionService.GetPotionByStudentId(studentId));
        }

    }
}
