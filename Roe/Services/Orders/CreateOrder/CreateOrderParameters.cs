namespace Roe.Services.Orders.CreateOrder;

public class CreateOrderParameters
{
    public int CustomerId { get; set; }
    
    public int FactoryId { get; set; }

    public string Description { get; set; } = null!;

    public string Comments { get; set; } = null!;
    
    public int OrderStatusId { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public bool HasShipping { get; set; }
    
    public DateTime DeliveryDate { get; set; }
    
    public bool NotifyCustomer { get; set; }
    
    public bool HasExtras { get; set; }
    
    public int OrderTemplateId { get; set; }
}