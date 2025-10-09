using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities;

public class Author
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [StringLength(50)]
    public string? Firstname { get; set; }
    [StringLength(50)]
    public string? Lastname { get; set; }
    [StringLength(50)]
    public string? Country { get; set; }
    public DateTime Birthdate { get; set; }
}