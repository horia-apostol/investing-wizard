using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvestingWizard.Domain.Exchanges;

namespace InvestingWizard.Infrastructure.Data.Configurations
{
    public class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            builder.HasDiscriminator<string>("HolidayType")
                   .HasValue<Holiday>("RegularHoliday")
                   .HasValue<EarlyCloseDay>("EarlyCloseDay");

        }
    }
}
