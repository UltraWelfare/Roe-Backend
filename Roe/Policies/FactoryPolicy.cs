using Microsoft.EntityFrameworkCore;
using Roe.Entities;

namespace Roe.Policies;

public class FactoryPolicy(RoeContext db)
{
    public Task<bool> HasOwnership(string userId, int factoryId)
    {
        return db.UserFactories.AnyAsync(userFactory =>
            userFactory.UserId == userId && userFactory.FactoryId == factoryId);
    }
    
    
    public Task<bool> HasOwnership(string userId, string factorySlug)
    {
        return db.UserFactories.AnyAsync(userFactory =>
            userFactory.UserId == userId && userFactory.Factory.Slug == factorySlug);
    }
}