namespace Roe.Services.OrderStatuses.CreateOrderStatus;

public class CreateOrderStatusResponse
{
    public int Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public bool IsDefault { get; set; }
}