using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.TransferObjects;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UsersService _service;

    public UsersController(MyDbContext context)
    {
        _service = new UsersService(context);
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }
    
    [HttpGet("me")]
    public IActionResult GetMe()
    {
        int userId = HttpContext.Items["UserId"] is int id ? id : -1;
        Console.WriteLine(HttpContext.Items.ToString());
        if (userId == -1)
        {
            return Unauthorized();
        }
        
        var user = _service.GetById(userId);
        if (user == null)
            return NotFound();
        
        return Ok(user);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var user = _service.GetById(id);
        if (user == null)
            return NotFound();
        
        return Ok(user);
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, UserDto userDto)
    {
        return Ok(_service.Update(id, userDto));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok();
    }
}