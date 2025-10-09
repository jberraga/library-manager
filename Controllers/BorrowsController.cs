using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.TransferObjects;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowsController : ControllerBase
{
    private readonly BorrowsService _service;

    public BorrowsController(MyDbContext context)
    {
        _service = new BorrowsService(context);
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var borrow = _service.GetById(id);
        if (borrow == null)
            return NotFound();
        return Ok(borrow);
    }

    [HttpPost]
    public IActionResult Post(BorrowDto borrowDto)
    {
        return Ok(_service.Create(borrowDto));
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, BorrowDto borrowDto)
    {
        return Ok(_service.Update(id, borrowDto));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok();
    }
}