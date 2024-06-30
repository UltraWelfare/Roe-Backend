namespace Roe.Controllers.OrderStatus;

public class CreateOrderStatusRequest
{
    public string Title { get; set; } = null!;
    
    public bool IsDefault { get; set; }
}