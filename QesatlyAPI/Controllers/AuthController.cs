using Microsoft.AspNetCore.Mvc;
using Qesatly.Service.Abstracts;
using Qesatly.Service.DTO;

namespace QesatlyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var response = await _authService.LoginAsync(loginDto);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
