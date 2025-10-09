namespace WebApplication1.Data.TransferObjects;

public class AuthorDto
{
    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Country { get; set; }
    public DateTime Birthdate { get; set; }
}