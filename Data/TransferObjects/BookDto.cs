namespace WebApplication1.Data.TransferObjects;

public class BookDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Pages { get; set; }
    public int? AuthorId { get; set; }
    public int CategoryId { get; set; }
}