using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.TransferObjects;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly AuthorsService _service;

    public AuthorsController(MyDbContext context)
    {
        _service = new AuthorsService(context);
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var author = _service.GetById(id);
        if (author == null)
            return NotFound();
        
        return Ok(author);
    }
    
    [HttpPost]
    public IActionResult Post(AuthorDto authorDto)
    {
        return Ok(_service.Create(authorDto));
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, AuthorDto authorDto)
    {
        return Ok(_service.Update(id, authorDto));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok();
    }
}