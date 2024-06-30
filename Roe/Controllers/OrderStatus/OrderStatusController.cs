using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roe.Services.OrderStatuses;
using Roe.Services.OrderStatuses.CreateOrderStatus;
using Roe.Services.OrderStatuses.GetOrderStatus;

namespace Roe.Controllers.OrderStatus;

[ApiController]
[Route("factory/{factoryId:int}/[controller]")]
public class OrderStatusController(OrderStatusService orderStatusService): BaseController
{
    [HttpGet("")]
    [Authorize]
    public async Task<List<GetOrderStatusItem>> GetOrderStatuses(int factoryId)
    {
        return await orderStatusService.GetOrderStatuses(CurrentUserId, factoryId);
    }
    
    [HttpPost("")]
    [Authorize]
    public async Task<CreateOrderStatusResponse> CreateOrderStatus(int factoryId, [FromBody] CreateOrderStatusRequest request)
    {
        return await orderStatusService.CreateOrderStatus(CurrentUserId, new CreateOrderStatusParameters
        {
            Title = request.Title,
            IsDefault = request.IsDefault,
            FactoryId = factoryId
        });
    }
}