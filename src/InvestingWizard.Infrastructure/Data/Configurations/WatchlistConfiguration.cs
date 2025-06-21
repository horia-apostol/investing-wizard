using InvestingWizard.Domain.Watchlists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestingWizard.Infrastructure.Data.Configurations
{
    internal class WatchlistConfiguration : IEntityTypeConfiguration<Watchlist>
    {
        public void Configure(EntityTypeBuilder<Watchlist> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.UserId);
            builder.Property(w => w.Name);

            builder.Property(w => w.SecurityCodes);
        }
    }
}
