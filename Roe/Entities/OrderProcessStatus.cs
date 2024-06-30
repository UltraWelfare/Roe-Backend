using Microsoft.AspNetCore.Identity;

namespace Roe.Entities;

public class OrderProcessStatus
{
    public int Id { get; set; }
    
    public int OrderProcessId { get; set; }
    public OrderProcess OrderProcess { get; set; } = null!;
    
    public int StartedByUserId { get; set; }
    public IdentityUser StartedByUser { get; set; } = null!;
    
    public int? EndedByUserId { get; set; }
    public IdentityUser? EndedByUser { get; set; }
    
    public DateTime StartedAt { get; set; }
    
    public DateTime? EndedAt { get; set; }
    
    public OrderProcessStatusEnum Status { get; set; }

    public string Comments { get; set; } = null!;

}