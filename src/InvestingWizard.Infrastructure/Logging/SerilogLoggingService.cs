using InvestingWizard.Application.Shared.Interfaces;
using Serilog;

namespace InvestingWizard.Infrastructure.Logging
{
    public class SerilogLoggingService : ILoggingService
    {
        public void LogInformation(string message, params object[] args)
        {
            Log.Information(message, args);
        }
        public void LogWarning(string message, params object[] args)
        {
            Log.Warning(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            Log.Error(message, args);
        }
    }
}
