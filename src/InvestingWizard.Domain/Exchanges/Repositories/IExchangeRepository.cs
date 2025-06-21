using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Interfaces.Repositories;

namespace InvestingWizard.Domain.Exchanges.Repositories
{
    public interface IExchangeRepository : IAsyncRepository<Exchange>
    {
        Task<Result<Exchange>> GetExchangeByCode(string code);
    }
}
