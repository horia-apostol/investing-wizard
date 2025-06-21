using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Exchanges;
using InvestingWizard.Domain.Exchanges.Repositories;
using InvestingWizard.Infrastructure.Data.Contexts;
using InvestingWizard.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace InvestingWizard.Infrastructure.Data.Repositories
{
    internal class ExchangeRepository(MainContext context) : Repository<Exchange>(context), IExchangeRepository
    {
        private readonly MainContext _context = context;
        public async Task<Result<Exchange>> GetExchangeByCode(string code)
        {
            var result = await _context.Exchanges
                .AsNoTracking()
                .Where(e => e.Code == code)
                .Select(e => new
                {
                    e.Name,
                    e.Code,
                    e.OperatingMIC,
                    e.Country,
                    e.CurrencyCode,
                    e.TimeZone,
                    e.Holidays,
                    e.TradingHours
                })
                .FirstOrDefaultAsync();

            if (result == null) { return CommonErrors.EntityNotFound; }

            var exchange = Exchange.Create(code, result.CurrencyCode, result.Name, result.OperatingMIC, result.Country, result.TimeZone);

            foreach (var holiday in result.Holidays)
            {
                exchange.AddHoliday(holiday);
            }

            exchange.UpdateTradingHours(result.TradingHours);
            return exchange;
        }
    }
}
