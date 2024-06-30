namespace Roe.Entities;

public class Order
{
    public int Id { get; set; }
    
    public int FactoryId { get; set; }
    public Factory Factory { get; set; } = null!;
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public string Comments { get; set; } = null!;
    
    public int OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; } = null!;
    
    public DateTime OrderDate { get; set; }
    
    public bool HasShipping { get; set; }
    
    public DateTime? DeliveryDate { get; set; }
    
    public bool NotifyCustomer { get; set; }
    
    public bool HasExtras { get; set; }
    
    public List<OrderProcess> OrderProcesses { get; set; } = null!;
    
    
}