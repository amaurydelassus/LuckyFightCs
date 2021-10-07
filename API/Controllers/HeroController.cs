using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly ILogger<HeroController> _logger;

        public HeroController(ILogger<HeroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Hero> GetHeroes()
        {
            using (var db = new DatabaseContext())
            {
                var heroes =
                    db
                        .Heroes
                        .Include(h => h.User)
                        .OrderByDescending(h => h.NbFights)
                        .ToList();
                return heroes;
            }
        }

        [HttpGet]
        [Route("podium")]
        public List<Hero> GetPodium()
        {
            using (var db = new DatabaseContext())
            {
                var heroes =
                    db
                        .Heroes
                        .Include(h => h.User)
                        .OrderByDescending(h => h.NbFights)
                        .Take(3)
                        .ToList();
                return heroes;
            }
        }

        [HttpGet]
        [Route("champion")]
        public Hero GetChampion()
        {
            using (var db = new DatabaseContext())
            {
                var hero =
                    db
                        .Heroes
                        .Include(h => h.User)
                        .Where(h => h.IsChampion == true)
                        .ToList()
                        .First();
                return hero;
            }
        }

        [HttpGet]
        [Route("myheroes/{id}")]
        public List<Hero> GetMyHeroes(int id)
        {
            using (var db = new DatabaseContext())
            {
                var heroes =
                    db
                        .Heroes
                        .Include(h => h.User)
                        .Where(h => h.User.Id == id)
                        .OrderBy(h => h.NbFights)
                        .ToList();
                return heroes;
            }
        }

        [HttpGet]
        [Route("onehero/{id}")]
        public Hero GetOneHero(int id)
        {
            using (var db = new DatabaseContext())
            {
                var hero = db.Heroes.Find(id);
                return hero;
            }
        }

        [HttpPost]
        [Route("new")]
        public IActionResult PostHero(Hero hero)
        {
            if (hero.Name == null)
            {
                return NoContent();
            }
            else
            {
                using (var db = new DatabaseContext())
                {
                    hero.IsChampion = false;
                    hero.NbFights = 0;
                    hero.Id = 0;
                    User user =
                        db
                            .Users
                            .Where(u => u.Id == hero.User.Id)
                            .ToList()
                            .First();
                    hero.User = user;
                    db.Heroes.Update (hero);
                    db.SaveChanges();
                    return Ok($"Hero {hero.Id} {hero.Name} added");
                }
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteHero(int id)
        {
            using (var db = new DatabaseContext())
            {
                var hero =
                    db
                        .Heroes
                        .Where(h => h.Id == id)
                        .ToList()
                        .FirstOrDefault(null);
                if (hero == null)
                {
                    return NoContent();
                }
                else
                {
                    db.Remove (hero);
                    db.SaveChanges();
                    return Ok($"Hero {hero.Name} deleted");
                }
            }
        }

        [HttpPut]
        [Route("name/{id}")]
        public IActionResult UpdateName(int id, Hero hero)
        {
            using (var db = new DatabaseContext())
            {
                Hero h = db.Heroes.Find(id);
                if (h == null)
                {
                    return NoContent();
                }
                else
                {
                    h.Name = hero.Name;
                    h.Icon = hero.Icon;
                    h.Pv = hero.Pv;
                    h.Atk = hero.Atk;
                    h.IsSwag = hero.IsSwag;
                    h.NbFights = hero.NbFights;
                    h.IsChampion = hero.IsChampion;
                    db.Update (h);
                    db.SaveChanges();
                    return Ok($"Hero {id} {hero.Name} is updated");
                }
            }
        }
    }
}
