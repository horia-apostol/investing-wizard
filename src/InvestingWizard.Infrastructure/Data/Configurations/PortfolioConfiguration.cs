
using InvestingWizard.Domain.Portfolios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestingWizard.Infrastructure.Data.Configurations
{
    internal class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UserId);
            builder.Property(p => p.Name);

            builder.OwnsMany(builder => builder.Transactions, transactions =>
            {
                transactions.WithOwner();
            });
            builder.OwnsMany(builder => builder.PortfolioEntries, entries =>
            {
                entries.WithOwner();
            });
        }
    }
}
