namespace Roe.Entities;

public class Factory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;
    
    public List<UserFactory> UserFactories { get; set; } = null!;
}