namespace Roe.Services.OrderTemplates.CreateOrderTemplate;

public class CreateOrderTemplateParameters
{
    public string Title { get; set; } = null!;
    
    public List<int> ProcessIds { get; set; } = null!;
}