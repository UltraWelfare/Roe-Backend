using System.Security;
using Microsoft.EntityFrameworkCore;
using Roe.Entities;
using Roe.Policies;
using Roe.Services.Processes.CreateProcess;
using Roe.Services.Processes.GetProcess;

namespace Roe.Services.Processes;

public class ProcessService(RoeContext db, FactoryPolicy factoryPolicy)
{
    public async Task<List<GetProcessItem>> GetProcesses(string userId, string factorySlug)
    {
        if (!await factoryPolicy.HasOwnership(userId, factorySlug)) throw new SecurityException();
        
        var processes = await db.Processes
            .Where(p => p.Factory.Slug == factorySlug)
            .Select(p => new GetProcessItem
            {
                Id = p.Id,
                Title = p.Title
            })
            .ToListAsync();
        return processes;
    }
    
    public async Task CreateProcess(string userId, string factorySlug, CreateProcessParameters parameters)
    {
        if (!await factoryPolicy.HasOwnership(userId, factorySlug)) throw new SecurityException();
        
        var factoryId = await db.Factories
            .Where(f => f.Slug == factorySlug)
            .Select(f => f.Id)
            .FirstOrDefaultAsync();
        
        
        var process = new Process()
        {
            Title = parameters.Title,
            FactoryId = factoryId
        };
        
        db.Processes.Add(process);
        await db.SaveChangesAsync();
    }
}