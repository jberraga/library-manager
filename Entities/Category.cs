using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required, StringLength(32)]
    public string? Name { get; set; }
    [StringLength(1024)]
    public string? Description { get; set; }
    public int AgeRestriction { get; set; }

    public override string ToString()
    {
        return $"Category() -> Id: {Name}, Name: {Name}, Description: {Description}, AgeRestriction: {AgeRestriction}";
    }
}