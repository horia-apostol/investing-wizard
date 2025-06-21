using InvestingWizard.Domain.Companies;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Shared.Interfaces
{
    public interface IDividendOrchestrationService
    {
        Task<Result<DividendRateResult>> GetDividendByIdAsync(Guid id);
    }
}