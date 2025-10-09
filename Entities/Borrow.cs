using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace WebApplication1.Entities;

public class Borrow
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime Date  { get; set; }
    public int Duration { get; set; }
    [ForeignKey("Book")]
    public int BookId { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }

    public override string ToString()
    {
        return $"Borrow() -> Id {Id}, Date: {Date}, Duration: {Duration}, BookId: {BookId}, UserId: {UserId}";
    }
}