using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            using (var db = new DatabaseContext())
            {
                var users = db.Users.ToList();
                return users;
            }
        }

        [HttpPost]
        [Route("new/{email}")]
        public IActionResult PostUser(string email)
        {
            using (var db = new DatabaseContext())
            {
                User user = { 0, email };
                db.Users.Add (user);
                db.SaveChanges();
                return Ok($"User {user.Id} added");
            }
        }

        [HttpGet]
        [Route("get/{email}")]
        public User GetUserFromEmail(string email)
        {
            using (var db = new DatabaseContext())
            {
                var user =
                    db
                        .Users
                        .Where(u => u.Email == email)
                        .ToList()
                        .FirstOrDefault(null);
                return user;
            }
        }
    }
}
