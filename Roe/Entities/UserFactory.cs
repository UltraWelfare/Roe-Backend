using Microsoft.AspNetCore.Identity;

namespace Roe.Entities;

public class UserFactory
{
    public int Id { get; set; }
    
    public string UserId { get; set; }
    public IdentityUser User { get; set; } = null!;
    
    public int FactoryId { get; set; }
    public Factory Factory { get; set; } = null!;
    
    public bool IsOwner { get; set; }
}