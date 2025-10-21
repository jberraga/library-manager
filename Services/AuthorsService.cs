using WebApplication1.Data;
using WebApplication1.Data.TransferObjects;
using WebApplication1.Entities;

namespace WebApplication1.Services;

public class AuthorsService
{
    private readonly MyDbContext _context;

    public AuthorsService(MyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<AuthorDto> GetAll()
    {
        return _context.Authors.Select(a => new AuthorDto
        {
            Id = a.Id,
            Firstname = a.Firstname,
            Lastname = a.Lastname,
            Country = a.Country,
            Birthdate = a.Birthdate
        }).ToList();
    }

    public AuthorDto? GetById(int id)
    {
        var a = _context.Authors.FirstOrDefault(a => a.Id == id);
        if (a == null) return null;
        return new AuthorDto
        {
            Id = a.Id,
            Firstname = a.Firstname,
            Lastname = a.Lastname,
            Country = a.Country,
            Birthdate = a.Birthdate
        };
    }

    public int Create(AuthorDto dto)
    {
        var author = new Author
        {
            Firstname = dto.Firstname,
            Lastname = dto.Lastname,
            Country = dto.Country,
            Birthdate = dto.Birthdate
        };
        _context.Authors.Add(author);
        _context.SaveChanges();
        return author.Id;
    }

    public AuthorDto? Update(int id, AuthorDto dto)
    {
        var author = _context.Authors.FirstOrDefault(a => a.Id == id);
        if (author == null) return null;
        author.Firstname = dto.Firstname;
        author.Lastname = dto.Lastname;
        author.Country = dto.Country;
        author.Birthdate = dto.Birthdate;
        _context.SaveChanges();
        return new AuthorDto
        {
            Id = author.Id,
            Firstname = author.Firstname,
            Lastname = author.Lastname,
            Country = author.Country,
            Birthdate = author.Birthdate
        };
    }

    public bool Delete(int id)
    {
        var author = _context.Authors.FirstOrDefault(a => a.Id == id);
        if (author == null) return false;
        _context.Authors.Remove(author);
        _context.SaveChanges();
        return true;
    }
}
