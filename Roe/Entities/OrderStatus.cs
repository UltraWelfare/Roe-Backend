namespace Roe.Entities;

public class OrderStatus
{
    public int Id { get; set; }
    
    public int FactoryId { get; set; }
    public Factory Factory { get; set; } = null!;
    
    public string Title { get; set; } = null!;
    
    public bool IsDefault { get; set; }
}