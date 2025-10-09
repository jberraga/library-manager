using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required, StringLength(32)]
    public string? Name {get; set;}
    public int Pages {get; set;}
    [ForeignKey("Author")]
    public int? AuthorId {get; set;}
    [ForeignKey("Category")]
    public int CategoryId {get; set;}

    public override string ToString()
    {
        return $"Book() -> Id: {Id}, Name: {Name}, Author: {AuthorId}, Pages: {Pages}, CategoryId: {CategoryId}";
    }
}