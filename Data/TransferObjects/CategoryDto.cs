namespace WebApplication1.Data.TransferObjects;

public class CategoryDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int AgeRestriction { get; set; }
}