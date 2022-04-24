using BooksClub_v2._0.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksClub_v2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromQuery] string user, string password)
        {
            string token = _userService.Authenticate(user, password);

            if (string.IsNullOrWhiteSpace(token))
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(token);
        }
    }
}
