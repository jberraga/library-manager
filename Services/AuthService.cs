using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Data;
using WebApplication1.Data.TransferObjects;
using WebApplication1.Entities;

namespace WebApplication1.Services;

public class AuthService
{
    private readonly MyDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(MyDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public AuthResponseDto? Login(LoginDto loginDto)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email);
        
        if (user == null)
            return null;

        if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            return null;

        var token = GenerateJwtToken(user);
        
        return new AuthResponseDto
        {
            Token = token,
            User = new UserDto
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Phone = user.Phone,
                Languages = user.Languages,
                Age = user.Age
            }
        };
    }

    public AuthResponseDto? Register(RegisterDto registerDto)
    {
        if (_context.Users.Any(u => u.Email == registerDto.Email))
            return null;

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

        var user = new User
        {
            Firstname = registerDto.Firstname,
            Lastname = registerDto.Lastname,
            Email = registerDto.Email,
            Phone = registerDto.Phone,
            Password = hashedPassword,
            Languages = registerDto.Languages,
            Age = registerDto.Age
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        var token = GenerateJwtToken(user);

        return new AuthResponseDto
        {
            Token = token,
            User = new UserDto
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Phone = user.Phone,
                Languages = user.Languages,
                Age = user.Age
            }
        };
    }

    private string GenerateJwtToken(User user)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"] ?? "fGEbuw9ja2kJiYghWFRp/cpXYV4NPInqCNeUKp7tD47v2tHDPRJsnLkf4LDb41O4/nHjYBrBLn1Rdas7SHpsB3OA=="; // only for dev
        var issuer = jwtSettings["Issuer"] ?? "WebApplication1";
        var audience = jwtSettings["Audience"] ?? "WebApplication1";
        var expiryMinutes = int.Parse(jwtSettings["ExpiryMinutes"] ?? "60");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

