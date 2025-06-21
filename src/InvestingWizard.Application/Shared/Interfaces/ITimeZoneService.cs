namespace InvestingWizard.Application.Shared.Interfaces
{
    public interface ITimeZoneService
    {
        DateTime GetCurrentTimeInTimeZone(string timeZone);
    }
}
