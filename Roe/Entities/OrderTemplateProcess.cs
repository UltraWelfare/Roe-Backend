namespace Roe.Entities;

public class OrderTemplateProcess
{
    public int Id { get; set; }
    
    public int OrderTemplateId { get; set; }
    public OrderTemplate OrderTemplate { get; set; } = null!;
    
    public int ProcessId { get; set; }
    public Process Process { get; set; } = null!;
    
    public int Sequence { get; set; }
}