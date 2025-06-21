using InvestingWizard.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace InvestingWizard.Infrastructure.Data.Factories
{
    internal class MainContextFactory 
        : IDesignTimeDbContextFactory<MainContext>
    {
        public MainContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("infrastructuresettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MainContext>();
            var connectionString = configuration.GetConnectionString("MainDBConnection");
            builder.UseNpgsql(connectionString);

            return new MainContext(builder.Options);
        }
    }
}
