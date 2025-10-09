using WebApplication1.Data;
using WebApplication1.Data.TransferObjects;
using WebApplication1.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services;

public class CategoriesService
{
    private readonly MyDbContext _context;

    public CategoriesService(MyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CategoryDto> GetAll()
    {
        return _context.Categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            AgeRestriction = c.AgeRestriction
        }).ToList();
    }

    public CategoryDto? GetById(int id)
    {
        var c = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (c == null) return null;
        return new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            AgeRestriction = c.AgeRestriction
        };
    }

    public int Create(CategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
            Description = dto.Description,
            AgeRestriction = dto.AgeRestriction
        };
        _context.Categories.Add(category);
        _context.SaveChanges();
        return category.Id;
    }

    public CategoryDto? Update(int id, CategoryDto dto)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null) return null;
        category.Name = dto.Name;
        category.Description = dto.Description;
        category.AgeRestriction = dto.AgeRestriction;
        _context.SaveChanges();
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            AgeRestriction = category.AgeRestriction
        };
    }

    public bool Delete(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null) return false;
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return true;
    }
}
