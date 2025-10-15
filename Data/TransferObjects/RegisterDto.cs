using System.ComponentModel.DataAnnotations;
using WebApplication1.Attributes;

namespace WebApplication1.Data.TransferObjects;

public class RegisterDto
{
    [Required, StringLength(32)]
    public string Firstname { get; set; }
    [Required, StringLength(32)]
    public string Lastname { get; set; }
    [Required, EmailAddress, NoTempEmail, StringLength(64)]
    public string Email { get; set; }
    [Required, Phone, StringLength(15)]
    public string? Phone { get; set; }
    [Required, StringLength(128, MinimumLength = 8)]
    public string Password { get; set; }
    public List<string>? Languages { get; set; }
    public int Age { get; set; }
}

