using InvestingWizard.Domain.Companies;
using InvestingWizard.Domain.Currencies;
using InvestingWizard.Domain.Exchanges;
using InvestingWizard.Domain.Portfolios;
using InvestingWizard.Domain.Prices;
using InvestingWizard.Domain.Watchlists;
using InvestingWizard.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Serilog;

namespace InvestingWizard.Infrastructure.Data.Contexts
{
    public class MainContext(DbContextOptions<MainContext> options) 
        : DbContext(options)
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddSerilog(); }))
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(warnings =>
                    warnings.Ignore(RelationalEventId.OptionalDependentWithAllNullPropertiesWarning));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new ExchangeConfiguration());
            modelBuilder.ApplyConfiguration(new PortfolioConfiguration());
            modelBuilder.ApplyConfiguration(new PriceConfiguration());
            modelBuilder.ApplyConfiguration(new WatchlistConfiguration());
            modelBuilder.ApplyConfiguration(new HolidayConfiguration());
        }
    }
}
