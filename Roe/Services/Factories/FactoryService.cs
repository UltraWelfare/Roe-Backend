using Microsoft.EntityFrameworkCore;
using Roe.Entities;
using Roe.Services.Factories.CreateFactory;
using Roe.Services.Factories.GetFactory;

namespace Roe.Services.Factories;

public class FactoryService(RoeContext db)
{
    public async Task<List<GetFactoryItem>> GetFactories(string userId)
    {
        var dbFactories = await db.Factories
            .Where(f => f.UserFactories.Any(uf => uf.UserId == userId))
            .Select(f => new GetFactoryItem
            {
                Id = f.Id,
                Name = f.Name,
                Slug = f.Slug
            })
            .ToListAsync();

        return dbFactories;
    }
    
    public async Task<Factory> GetFactoryBySlug(string userId, string slug)
    {
        var factory = await db.Factories
            .Include(f => f.UserFactories)
            .FirstOrDefaultAsync(f => f.Slug == slug && f.UserFactories.Any(uf => uf.UserId == userId));
        if (factory == null)
            throw new Exception("Factory not found");
        return factory;
    }

    public async Task<CreateFactoryResponse> CreateFactory(string userId, CreateFactoryParameters parameters)
    {
        var duplicate = await db.Factories
            .AnyAsync(f => f.Name == parameters.Name && f.UserFactories.Any(uf => uf.UserId == userId)
            );
        if (duplicate)
            throw new Exception("Factory already exists for this user");
        
        var duplicateSlug = await db.Factories
            .AnyAsync(f => f.Slug == parameters.Slug);
        if (duplicateSlug)
            throw new Exception("Slug already exists");

        var factory = new Factory
        {
            Name = parameters.Name,
            Slug = parameters.Slug
        };
        db.Factories.Add(factory);
        await db.SaveChangesAsync();

        db.UserFactories.Add(new UserFactory()
        {
            UserId = userId,
            FactoryId = factory.Id,
            IsOwner = true
        });
        await db.SaveChangesAsync();

        return new CreateFactoryResponse
        {
            Id = factory.Id,
            Name = factory.Name,
            Slug = factory.Slug
        };
    }
}