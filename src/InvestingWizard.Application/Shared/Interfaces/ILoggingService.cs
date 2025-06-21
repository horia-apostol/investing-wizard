namespace InvestingWizard.Application.Shared.Interfaces
{
    public interface ILoggingService
    {
        void LogInformation(string message, params object[] args);
        void LogWarning (string message, params object[] args);
        void LogError(string message, params object[] args);
    }
}
