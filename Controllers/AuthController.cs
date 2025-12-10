using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(AuthService authService) : ControllerBase
    {
        private readonly AuthService _authService = authService;

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser()
        {
            return Ok(_authService.LoginUser());
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser()
        {
            return Ok("Registered");
        }
    }
}