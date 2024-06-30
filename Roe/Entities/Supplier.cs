namespace Roe.Entities;

public class Supplier
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string Address { get; set; } = null!;
    
    public string City { get; set; } = null!;
    
    public string State { get; set; } = null!;
    
    public string Zip { get; set; } = null!;
    
    public string Phone1 { get; set; } = null!;
    
    public string Phone2 { get; set; } = null!;

    public string Comments { get; set; } = null!;
}