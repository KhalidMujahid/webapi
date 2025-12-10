using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dto;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(ApplicationDbContext applicationDbContext,UserService userService) : ControllerBase
    {
        private readonly ApplicationDbContext _context = applicationDbContext;
        private readonly UserService _userService = userService;
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new { message = "Single user", user });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound(new { message = "User not found!" });
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] IUser _user)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound(new { message = "User not found!" });
            }

            user.Name = _user.Name;
            user.Email = _user.Email;

            _context.Users.Update(user);
            _context.SaveChanges();

            return Ok(new { message = "User updated successfully!", user });
        }

    }
}