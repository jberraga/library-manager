using System.ComponentModel.DataAnnotations;
using WebApplication1.Attributes;

namespace WebApplication1.Data.TransferObjects;

public class LoginDto
{
    [EmailAddress, StringLength(64)]
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}