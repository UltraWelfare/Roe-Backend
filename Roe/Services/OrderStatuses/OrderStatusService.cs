using System.Security;
using Microsoft.EntityFrameworkCore;
using Roe.Entities;
using Roe.Policies;
using Roe.Services.OrderStatuses.CreateOrderStatus;
using Roe.Services.OrderStatuses.GetOrderStatus;

namespace Roe.Services.OrderStatuses;

public class OrderStatusService(RoeContext db, FactoryPolicy factoryPolicy)
{
    public async Task<List<GetOrderStatusItem>> GetOrderStatuses(string userId, int factoryId)
    {
        if (!await factoryPolicy.HasOwnership(userId, factoryId)) throw new SecurityException();

        return await db.OrderStatuses
            .Where(x => x.FactoryId == factoryId)
            .Select(x => new GetOrderStatusItem
            {
                Id = x.Id,
                Title = x.Title,
                IsDefault = x.IsDefault
            })
            .ToListAsync();
    }

    public async Task<CreateOrderStatusResponse> CreateOrderStatus(string userId,
        CreateOrderStatusParameters parameters)
    {
        if (!await factoryPolicy.HasOwnership(userId, parameters.FactoryId)) throw new SecurityException();
        
        var orderStatus = new OrderStatus()
        {
            FactoryId = parameters.FactoryId,
            Title = parameters.Title,
            IsDefault = parameters.IsDefault
        };

        db.OrderStatuses.Add(orderStatus);
        await db.SaveChangesAsync();

        return new CreateOrderStatusResponse()
        {
            Id = orderStatus.Id,
            Title = orderStatus.Title,
            IsDefault = orderStatus.IsDefault
        };
    }
}