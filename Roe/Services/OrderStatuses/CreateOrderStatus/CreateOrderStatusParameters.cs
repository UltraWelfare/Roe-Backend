namespace Roe.Services.OrderStatuses.CreateOrderStatus;

public class CreateOrderStatusParameters
{
    public int FactoryId { get; set; }
    
    public string Title { get; set; } = null!;
    
    public bool IsDefault { get; set; }
}