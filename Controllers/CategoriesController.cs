using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.TransferObjects;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly CategoriesService _service;

    public CategoriesController(MyDbContext context)
    {
        _service = new CategoriesService(context);
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var category = _service.GetById(id);
        if (category == null)
            return NotFound();
        
        return Ok(category);
    }
    
    [HttpPost]
    public IActionResult Post(CategoryDto categoryDto)
    {
        return Ok(_service.Create(categoryDto));
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, CategoryDto categoryDto)
    {
        return Ok(_service.Update(id, categoryDto));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok();
    }
}