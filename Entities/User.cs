using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Attributes;

namespace WebApplication1.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required, StringLength(32)]
    public string? Firstname { get; set; }
    [Required, StringLength(24)]
    public string? Lastname { get; set; }
    [EmailAddress, NoTempEmail, StringLength(64)]
    public string? Email { get; set; }
    [Phone]
    public string? Phone { get; set; }
    [Required, StringLength(128)]
    public string? Password { get; set; }
    
    public List<string>? Languages  { get; set; }
    
    [Age]
    public int Age { get; set; }

    public override string ToString()
    {
        return $"User() -> Id: {Id},  Firstname: {Firstname}, Lastname: {Lastname}, Email: {Email}";
    }
}