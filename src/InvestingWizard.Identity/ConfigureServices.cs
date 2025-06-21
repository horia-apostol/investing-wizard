using InvestingWizard.Identity.Data.Contexts;
using InvestingWizard.Identity.Data.Initializers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvestingWizard.Identity
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddIdentityServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("UsersDbConnection")));

            return services;
        }
    }
}
