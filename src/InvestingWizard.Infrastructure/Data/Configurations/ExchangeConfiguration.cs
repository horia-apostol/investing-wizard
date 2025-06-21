using InvestingWizard.Domain.Exchanges;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InvestingWizard.Infrastructure.Data.Configurations
{
    internal class ExchangeConfiguration : IEntityTypeConfiguration<Exchange>
    {
        public void Configure(EntityTypeBuilder<Exchange> builder)
        {
            builder.HasKey(e => e.Code);
            builder.Property(e => e.CurrencyCode);
            builder.Property(e => e.Name);
            builder.Property(e => e.OperatingMIC);
            builder.Property(e => e.Country);
            builder.Property(e => e.TimeZone);

            builder.HasMany(e => e.Holidays);
            builder.OwnsOne(e => e.TradingHours, th =>
            {
                th.WithOwner();
            });
        }
    }
}
