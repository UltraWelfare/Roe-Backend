using System.Security;
using Microsoft.EntityFrameworkCore;
using Roe.Entities;
using Roe.Policies;
using Roe.Services.OrderTemplates.CreateOrderTemplate;
using Roe.Services.OrderTemplates.GetOrderTemplates;

namespace Roe.Services.OrderTemplates;

public class OrderTemplateService(RoeContext db, FactoryPolicy factoryPolicy)
{
    public async Task<List<GetOrderTemplateItem>> GetOrderTemplates(string userId, string factorySlug)
    {
        if (!await factoryPolicy.HasOwnership(userId, factorySlug)) throw new SecurityException();

        return await db.OrderTemplates
            .Where(x => x.Factory.Slug == factorySlug)
            .Select(x => new GetOrderTemplateItem
            {
                Id = x.Id,
                Title = x.Title,
                OrderTemplateProcesses = x.OrderTemplateProcesses
                    .OrderBy(orderTemplateProcess => orderTemplateProcess.Sequence)
                    .Select(orderTemplateProcess => new GetOrderTemplateItem.OrderTemplateProcess
                    {
                        Id = orderTemplateProcess.Id,
                        Sequence = orderTemplateProcess.Sequence,
                        Process = new GetOrderTemplateItem.Process()
                        {
                            Id = orderTemplateProcess.Process.Id,
                            Title = orderTemplateProcess.Process.Title
                        }
                    }).ToList()
            }).ToListAsync();
    }

    public async Task CreateOrderTemplate(string userId, string factorySlug, CreateOrderTemplateParameters parameters)
    {
        if (!await factoryPolicy.HasOwnership(userId, factorySlug)) throw new SecurityException();
        var factoryId = await db.Factories.Where(f => f.Slug == factorySlug).Select(f => f.Id).FirstOrDefaultAsync();
        if (factoryId == 0) throw new Exception("Factory not found");
        
        
        var orderTemplate = new OrderTemplate()
        {
            Title = parameters.Title,
            FactoryId = factoryId,
            OrderTemplateProcesses = []
        };

        // Todo check if process ids exist

        orderTemplate.OrderTemplateProcesses.AddRange(
            parameters.ProcessIds.Select((processId, index) => new OrderTemplateProcess
            {
                ProcessId = processId,
                Sequence = index + 1
            })
        );

        db.OrderTemplates.Add(orderTemplate);

        await db.SaveChangesAsync();
    }
}