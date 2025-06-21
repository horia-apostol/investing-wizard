using InvestingWizard.Identity.Data.Models;
using InvestingWizard.Identity.Misc;
using InvestingWizard.Shared.Misc.Const;
using Microsoft.AspNetCore.Identity;

namespace InvestingWizard.Identity.Data.Initializers
{
    public sealed class DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;

        public async Task SeedRolesAsync()
        {
            if (!await _roleManager.RoleExistsAsync(Roles.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }

            if (!await _roleManager.RoleExistsAsync(Roles.User))
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.User));
            }
        }

        public async Task SeedAdminAsync()
        {
            if (await _userManager.FindByEmailAsync(AdminCredentials.Email) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = AdminCredentials.Email,
                    Email = AdminCredentials.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, AdminCredentials.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.User);
                    await _userManager.AddToRoleAsync(user, Roles.Admin);
                }
            }
        }
    }
}
