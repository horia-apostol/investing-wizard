using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Shared.Interfaces
{
    public interface ITransactionOrchestrationService
    {
        Task<Result> AddTransactionAsync(Guid portfolioId, DateOnly date, string securityCode, decimal units, bool brokerIsResident);
    }
}
