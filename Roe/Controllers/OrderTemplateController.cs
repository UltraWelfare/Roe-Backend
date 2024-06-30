using Microsoft.AspNetCore.Mvc;
using Roe.Services.OrderTemplates;
using Roe.Services.OrderTemplates.CreateOrderTemplate;
using Roe.Services.OrderTemplates.GetOrderTemplates;

namespace Roe.Controllers;

[ApiController]
[Route("factory/{slug}/[controller]")]
public class OrderTemplateController(OrderTemplateService orderTemplateService): BaseController
{
    
    [HttpGet("")]
    public async Task<List<GetOrderTemplateItem>> GetOrderTemplates(string slug)
    {
        return await orderTemplateService.GetOrderTemplates(CurrentUserId, slug);
    }

    [HttpPost("")]
    public async Task CreateOrderTemplate(string slug, [FromBody] CreateOrderTemplateParameters parameters)
    {
        await orderTemplateService.CreateOrderTemplate(CurrentUserId, slug, parameters);
    }

}