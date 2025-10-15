using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Attributes;

namespace WebApplication1.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    
    public List<string>? Languages  { get; set; }
    
    [Age]
    public int Age { get; set; }

    public override string ToString()
    {
        return $"User() -> Id: {Id},  Firstname: {Firstname}, Lastname: {Lastname}, Email: {Email}";
    }
}