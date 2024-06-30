using Microsoft.AspNetCore.Identity;

namespace Roe.Entities;

public class SupplyOrder
{
    public int Id { get; set; }
    
    public int FactoryId { get; set; }
    public Factory Factory { get; set; } = null!;
    
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;
    
    public int SupplyOrderStatusId { get; set; }
    public SupplyOrderStatus SupplyOrderStatus { get; set; } = null!;
    
    public DateTime OrderDate { get; set; }
    
    public DateTime? ShouldArriveDate { get; set; }
    
    public DateTime? InvoiceDate { get; set; }
    
    public DateTime? ArriveDate { get; set; }

    public int NotifyUserId { get; set; }
    public IdentityUser NotifyUser { get; set; } = null!;
}