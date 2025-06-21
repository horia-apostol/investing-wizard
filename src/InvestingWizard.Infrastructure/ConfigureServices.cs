using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Domain.Currencies.Repositories;
using InvestingWizard.Domain.Exchanges.Repositories;
using InvestingWizard.Domain.Interfaces.Repositories;
using InvestingWizard.Domain.Prices.Repositories;
using InvestingWizard.Domain.Watchlists.Repositories;
using InvestingWizard.Infrastructure.Data.Contexts;
using InvestingWizard.Infrastructure.Data.Repositories;
using InvestingWizard.Infrastructure.Data.Repositories.Base;
using InvestingWizard.Infrastructure.Jobs;
using InvestingWizard.Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace InvestingWizard.Infrastructure
{
    public static class IoCServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IExchangeRepository, ExchangeRepository>();
            services.AddScoped<IPriceRepository, PriceRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IWatchlistRepository, WatchlistRepository>();

            services.AddScoped<ILoggingService, SerilogLoggingService>();

            services.AddDbContext<MainContext>(options => options.UseNpgsql(configuration.GetConnectionString("MainDBConnection")));

            services.AddQuartz(q =>
            {
                var jobKey = new JobKey("UpdatePricesJob");
                q.AddJob<UpdatePricesJob>(opts => opts.WithIdentity(jobKey));
                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("UpdatePricesJob-trigger")
                    .WithCronSchedule("0 0 0 * * ?"));
            });

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
            return services;
        }
    }
}
