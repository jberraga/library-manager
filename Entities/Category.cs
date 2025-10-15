using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int AgeRestriction { get; set; }

    public override string ToString()
    {
        return $"Category() -> Id: {Name}, Name: {Name}, Description: {Description}, AgeRestriction: {AgeRestriction}";
    }
}