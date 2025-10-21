using WebApplication1.Data;
using WebApplication1.Data.TransferObjects;
using WebApplication1.Entities;
namespace WebApplication1.Services;

public class BorrowsService
{
    private readonly MyDbContext _context;

    public BorrowsService(MyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<BorrowDto> GetAll()
    {
        return _context.Borrows.Select(b => new BorrowDto
        {
            Id = b.Id,
            Date = b.Date,
            Duration = b.Duration,
            BookId = b.BookId,
            UserId = b.UserId
        }).ToList();
    }

    public BorrowDto? GetById(int id)
    {
        var b = _context.Borrows.FirstOrDefault(b => b.Id == id);
        if (b == null) return null;
        return new BorrowDto
        {
            Id = b.Id,
            Date = b.Date,
            Duration = b.Duration,
            BookId = b.BookId,
            UserId = b.UserId
        };
    }

    public int Create(BorrowDto dto)
    {
        var borrow = new Borrow
        {
            Date = dto.Date,
            Duration = dto.Duration,
            BookId = dto.BookId,
            UserId = dto.UserId
        };
        _context.Borrows.Add(borrow);
        _context.SaveChanges();
        return borrow.Id;
    }

    public BorrowDto? Update(int id, BorrowDto dto)
    {
        var borrow = _context.Borrows.FirstOrDefault(b => b.Id == id);
        if (borrow == null) return null;
        borrow.Date = dto.Date;
        borrow.Duration = dto.Duration;
        borrow.BookId = dto.BookId;
        borrow.UserId = dto.UserId;
        _context.SaveChanges();
        return new BorrowDto
        {
            Id = borrow.Id,
            Date = borrow.Date,
            Duration = borrow.Duration,
            BookId = borrow.BookId,
            UserId = borrow.UserId
        };
    }

    public bool Delete(int id)
    {
        var borrow = _context.Borrows.FirstOrDefault(b => b.Id == id);
        if (borrow == null) return false;
        _context.Borrows.Remove(borrow);
        _context.SaveChanges();
        return true;
    }
}
