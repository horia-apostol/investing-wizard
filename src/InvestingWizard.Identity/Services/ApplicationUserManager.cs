using InvestingWizard.Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;

namespace InvestingWizard.Identity.Services
{
    public class ApplicationUserManager(
        IUserStore<ApplicationUser> store, 
        IOptions<IdentityOptions> optionsAccessor, 
        IPasswordHasher<ApplicationUser> passwordHasher, 
        IEnumerable<IUserValidator<ApplicationUser>> userValidators, 
        IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, 
        ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, 
        IServiceProvider services, 
        ILogger<UserManager<ApplicationUser>> logger) 
        : UserManager<ApplicationUser>(
            store, 
            optionsAccessor, 
            passwordHasher, 
            userValidators, 
            passwordValidators, 
            keyNormalizer, 
            errors, 
            services,
            logger)
    {
        public async Task<IdentityResult> UpdateUserInfoAsync(
            string userId, 
            string? firstName, 
            string? lastName, 
            string? preferredCurrencyCode)
        {
            var user = await FindByIdAsync(userId);
            if (user == null)
            {
                Logger.LogWarning("User with ID {UserId} not found", userId);
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }
            if (firstName is not null) user.SetFirstName(firstName);
            if (lastName is not null) user.SetLastName(lastName);
            if (preferredCurrencyCode is not null) user.SetPreferredCurrencyCode(preferredCurrencyCode);

            var result = await UpdateAsync(user);

            if (result.Succeeded)
            {
                Logger.LogInformation("User with ID {UserId} updated successfully", userId);
            }
            else
            {
                Logger.LogWarning("Failed to update user with ID {UserId}", userId);
            }

            return result;
        }
    }
}
