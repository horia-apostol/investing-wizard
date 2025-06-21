using InvestingWizard.Domain.Interfaces.Repositories;

namespace InvestingWizard.Domain.Currencies.Repositories
{
    public interface ICurrencyRepository : IAsyncRepository<Currency>;
}
