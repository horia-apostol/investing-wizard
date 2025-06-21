using InvestingWizard.Application.Shared.Interfaces;
using TimeZoneConverter;

namespace InvestingWizard.Infrastructure.Services
{
    public class TimeZoneService : ITimeZoneService
    {
        public DateTime GetCurrentTimeInTimeZone(string timeZone)
        {
            return TimeZoneInfo.ConvertTime(DateTime.UtcNow, TZConvert.GetTimeZoneInfo(timeZone));
        }
    }

}
