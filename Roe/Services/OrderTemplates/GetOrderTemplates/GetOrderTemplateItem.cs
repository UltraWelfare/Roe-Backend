namespace Roe.Services.OrderTemplates.GetOrderTemplates;

public class GetOrderTemplateItem
{
    public int Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public List<OrderTemplateProcess> OrderTemplateProcesses { get; set; } = null!;
    
    public class OrderTemplateProcess
    {
        public int Id { get; set; }

        public Process Process { get; set; } = null!;
        
        public int Sequence { get; set; }
    }
    
    public class Process
    {
        public int Id { get; set; }
        
        public string Title { get; set; } = null!;
    }
}
