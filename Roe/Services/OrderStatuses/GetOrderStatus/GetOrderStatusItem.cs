namespace Roe.Services.OrderStatuses.GetOrderStatus;

public class GetOrderStatusItem
{
    public int Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public bool IsDefault { get; set; }
}