using DisasterReady.Application.DTOs.Login.RequestDto;
using DisasterReady.Application.Services.AbstractServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // Example endpoint for login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            // Here you would typically call a method on _loginService to handle the login logic
            // For example:
            // var result = _loginService.Login(request.Username, request.Password);
            // return Ok(result);
            return Ok("Login endpoint hit successfully!"); // Placeholder response
        }
    }
}
