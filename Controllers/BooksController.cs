using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.TransferObjects;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BooksService _service;

    public BooksController(MyDbContext context)
    {
        _service = new BooksService(context);
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var book = _service.GetById(id);
        if (book == null)
            return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public IActionResult Post(BookDto bookDto)
    {
        return Ok(_service.Create(bookDto));
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, BookDto bookDto)
    {
        return Ok(_service.Update(id, bookDto));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok();
    }
}