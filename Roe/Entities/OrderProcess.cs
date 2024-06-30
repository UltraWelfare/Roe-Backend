namespace Roe.Entities;

public class OrderProcess
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public int ProcessId { get; set; }
    public Process Process { get; set; } = null!;
    
    public int Sequence { get; set; }
    
}