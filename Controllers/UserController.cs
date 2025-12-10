using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dto;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(ApplicationDbContext applicationDbContext) : ControllerBase
    {
        private readonly ApplicationDbContext _context = applicationDbContext;
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] IUser user)
        {
            var newUser = new Models.Users
            {
                Name = user.Name,
                Email = user.Email
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok(new { message = "User added to database", newUser });
        }
    }
}