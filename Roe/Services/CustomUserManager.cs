using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Roe.Services;

public class CustomUserManager(
    IUserStore<IdentityUser> store,
    IOptions<IdentityOptions> optionsAccessor,
    IPasswordHasher<IdentityUser> passwordHasher,
    IEnumerable<IUserValidator<IdentityUser>> userValidators,
    IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    IServiceProvider services,
    ILogger<UserManager<IdentityUser>> logger)
    : UserManager<IdentityUser>(store, optionsAccessor, passwordHasher, userValidators, passwordValidators,
        keyNormalizer, errors, services,
        logger)
{
    public override Task<IdentityResult> CreateAsync(IdentityUser user, string password)
    {
        var createdUser = base.CreateAsync(user, password);


        return createdUser;
    }
}