using HeroApi.Data;
using HeroApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly DataContext _context;

        public HeroController(DataContext context)
        {  
            _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> GetAllHeroes() 
        {
            var heroes = await _context.Heroes.ToListAsync();

            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null) 
                return NotFound("Hero not found");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Hero>>> AddHero(Hero hero)
        {
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Heroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Hero>>> UpdateHero(Hero updateHero)
        {
            var hero = await _context.Heroes.FindAsync(updateHero.Id);
            if (hero == null)
                return NotFound("Hero not found");

            hero.Name = updateHero.Name;
            hero.FirstName = updateHero.FirstName;
            hero.LastName = updateHero.LastName;
            hero.Place = updateHero.Place;
            await _context.SaveChangesAsync();

            return Ok(await _context.Heroes.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Hero>>> DeleteHero(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
                return NotFound("Hero not found");

            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Heroes.ToListAsync());
        }

    }
}
