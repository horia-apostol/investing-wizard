using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Interfaces.Repositories;

namespace InvestingWizard.Domain.Prices.Repositories
{
    public interface IPriceRepository : IAsyncRepository<Price>
    {
        Task <Result<Price>>GetByDateAndCodeAsync(DateOnly dateOnly, string code);
        Task<Result<List<Price>>> GetBySecurityCodeAsync(string code);
    }
}