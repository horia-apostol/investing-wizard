using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using InvestingWizard.Domain.Prices;

namespace InvestingWizard.Infrastructure.Data.Configurations
{
    internal class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(mp => mp.Id);

            builder.Property(mp => mp.SecurityCode);
            builder.Property(mp => mp.Date);
            builder.Property(mp => mp.Open);
            builder.Property(mp => mp.High);
            builder.Property(mp => mp.Low);
            builder.Property(mp => mp.Close);
            builder.Property(mp => mp.Volume);
            builder.Property(mp => mp.AdjustedClose);
        }
    }
}
