namespace Roe.Entities;

public class OrderTemplate
{
    public int Id { get; set; }
    
    public int FactoryId { get; set; }
    public Factory Factory { get; set; } = null!;
    
    public string Title { get; set; } = null!;
    
    public List<OrderTemplateProcess> OrderTemplateProcesses { get; set; } = null!;
}