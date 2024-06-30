using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roe.Entities;
using Roe.Services.OrderTemplates;
using Roe.Services.OrderTemplates.CreateOrderTemplate;
using Roe.Services.OrderTemplates.GetOrderTemplates;

namespace Roe.Controllers.OrderTemplates;

[ApiController]
[Route("factory/{slug}/[controller]")]
public class OrderTemplateController(OrderTemplateService orderTemplateService, RoeContext db) : BaseController
{

    [HttpGet("")]
    [Authorize]
    public async Task<List<GetOrderTemplateItem>> GetOrderTemplates(string slug)
    {
        return await orderTemplateService.GetOrderTemplates(CurrentUserId, slug);
    }

    [HttpPost("")]
    [Authorize]
    public async Task CreateOrderTemplate(string slug, [FromBody] CreateOrderTemplateParameters parameters)
    {
        await orderTemplateService.CreateOrderTemplate(CurrentUserId, slug, parameters);
    }

    [HttpPut("{orderTemplateId:int}")]
    [Authorize]
    public async Task<UpdateOrderTemplateResponse> UpdateOrderTemplate(string slug, int orderTemplateId, [FromBody] UpdateOrderTemplateParameters parameters)
    {
        var orderTemplate = await db.OrderTemplates.Where(entity => entity.Id == orderTemplateId && entity.Factory.Slug == slug).SingleAsync();
        orderTemplate.Title = parameters.Title;
        await db.SaveChangesAsync();
        return new UpdateOrderTemplateResponse { Id = orderTemplateId, Title = orderTemplate.Title };

    }

}