using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.TransferObjects;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _service;

    public AuthController(MyDbContext context, IConfiguration configuration)
    {
        _service = new AuthService(context, configuration);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto authorDto)
    {
        var token = _service.Login(authorDto);
        if (token == null)
            return Unauthorized();
        
        return Ok(token);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDto registerDto)
    {
        var token = _service.Register(registerDto);
        if (token == null)
            return BadRequest("User with this email already exists");
        
        return Ok(token);
    }
}