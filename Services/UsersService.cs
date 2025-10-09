using WebApplication1.Data;
using WebApplication1.Data.TransferObjects;
using WebApplication1.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services;

public class UsersService
{
    private readonly MyDbContext _context;

    public UsersService(MyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<UserDto> GetAll()
    {
        return _context.Users.Select(u => new UserDto
        {
            Id = u.Id,
            Firstname = u.Firstname,
            Lastname = u.Lastname,
            Email = u.Email,
            Phone = u.Phone,
            Languages = u.Languages,
            Age = u.Age
        }).ToList();
    }

    public UserDto? GetById(int id)
    {
        var u = _context.Users.FirstOrDefault(u => u.Id == id);
        if (u == null) return null;
        return new UserDto
        {
            Id = u.Id,
            Firstname = u.Firstname,
            Lastname = u.Lastname,
            Email = u.Email,
            Phone = u.Phone,
            Languages = u.Languages,
            Age = u.Age
        };
    }

    public int Create(UserDto dto)
    {
        var user = new User
        {
            Firstname = dto.Firstname,
            Lastname = dto.Lastname,
            Email = dto.Email,
            Phone = dto.Phone,
            Languages = dto.Languages,
            Age = dto.Age
        };
        _context.Users.Add(user);
        _context.SaveChanges();
        return user.Id;
    }

    public UserDto? Update(int id, UserDto dto)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return null;
        user.Firstname = dto.Firstname;
        user.Lastname = dto.Lastname;
        user.Email = dto.Email;
        user.Phone = dto.Phone;
        user.Languages = dto.Languages;
        user.Age = dto.Age;
        _context.SaveChanges();
        return new UserDto
        {
            Id = user.Id,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Email = user.Email,
            Phone = user.Phone,
            Languages = user.Languages,
            Age = user.Age
        };
    }

    public bool Delete(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return false;

        _context.Users.Remove(user);
        _context.SaveChanges();
        return true;
    }
}