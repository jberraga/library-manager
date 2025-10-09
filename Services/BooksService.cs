using WebApplication1.Data;
using WebApplication1.Data.TransferObjects;
using WebApplication1.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services;

public class BooksService
{
    private readonly MyDbContext _context;

    public BooksService(MyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<BookDto> GetAll()
    {
        return _context.Books.Select(b => new BookDto
        {
            Id = b.Id,
            Name = b.Name,
            Pages = b.Pages,
            AuthorId = b.AuthorId,
            CategoryId = b.CategoryId
        }).ToList();
    }

    public BookDto? GetById(int id)
    {
        var b = _context.Books.FirstOrDefault(b => b.Id == id);
        if (b == null) return null;
        return new BookDto
        {
            Id = b.Id,
            Name = b.Name,
            Pages = b.Pages,
            AuthorId = b.AuthorId,
            CategoryId = b.CategoryId
        };
    }

    public int Create(BookDto dto)
    {
        var book = new Book
        {
            Name = dto.Name,
            Pages = dto.Pages,
            AuthorId = dto.AuthorId,
            CategoryId = dto.CategoryId
        };
        _context.Books.Add(book);
        _context.SaveChanges();
        return book.Id;
    }

    public BookDto? Update(int id, BookDto dto)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (book == null) return null;
        book.Name = dto.Name;
        book.Pages = dto.Pages;
        book.AuthorId = dto.AuthorId;
        book.CategoryId = dto.CategoryId;
        _context.SaveChanges();
        return new BookDto
        {
            Id = book.Id,
            Name = book.Name,
            Pages = book.Pages,
            AuthorId = book.AuthorId,
            CategoryId = book.CategoryId
        };
    }

    public bool Delete(int id)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (book == null) return false;

        _context.Books.Remove(book);
        _context.SaveChanges();
        return true;
    }
}