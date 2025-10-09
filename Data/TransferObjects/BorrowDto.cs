namespace WebApplication1.Data.TransferObjects;

public class BorrowDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
}