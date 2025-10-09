namespace WebApplication1.Data.TransferObjects;

public class UserDto
{
    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public List<string>? Languages { get; set; }
    public int Age { get; set; }
}