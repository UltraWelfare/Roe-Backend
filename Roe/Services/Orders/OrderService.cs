using Microsoft.EntityFrameworkCore;
using Roe.Entities;
using Roe.Services.Orders.CreateOrder;

namespace Roe.Services.Orders;

public class OrderService(RoeContext db)
{
    public async Task CreateOrder(int userId, CreateOrderParameters parameters)
    {
        // TODO check if authorized

        var order = new Order
        {
            Description = parameters.Description,
            Comments = parameters.Comments,
            OrderDate = parameters.OrderDate,
            CustomerId = parameters.CustomerId,
            FactoryId = parameters.FactoryId,
            HasShipping = parameters.HasShipping,
            DeliveryDate = parameters.DeliveryDate,
            NotifyCustomer = parameters.NotifyCustomer,
            HasExtras = parameters.HasExtras,
            OrderStatusId = parameters.OrderStatusId,
        };


        var orderTemplate =
            await db.OrderTemplates
                .Include(template => template.OrderTemplateProcesses)
                .SingleOrDefaultAsync(template => template.FactoryId == parameters.FactoryId);
        if (orderTemplate is null)
            // TODO
            throw new InvalidOperationException();

        order.OrderProcesses.AddRange(
            orderTemplate.OrderTemplateProcesses.Select(template => new OrderProcess
            {
                ProcessId = template.ProcessId,
                Sequence = template.Sequence
            })
        );
        
        db.Orders.Add(order);

        await db.SaveChangesAsync();
    }
}