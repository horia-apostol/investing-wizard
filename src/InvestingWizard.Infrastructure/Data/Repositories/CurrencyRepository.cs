using InvestingWizard.Domain.Currencies;
using InvestingWizard.Domain.Currencies.Repositories;
using InvestingWizard.Infrastructure.Data.Contexts;
using InvestingWizard.Infrastructure.Data.Repositories.Base;

namespace InvestingWizard.Infrastructure.Data.Repositories
{
    internal class CurrencyRepository(MainContext context) : Repository<Currency>(context), ICurrencyRepository
    {
    }
}
