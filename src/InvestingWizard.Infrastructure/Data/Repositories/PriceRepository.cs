using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Prices;
using InvestingWizard.Domain.Prices.Repositories;
using InvestingWizard.Infrastructure.Data.Contexts;
using InvestingWizard.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace InvestingWizard.Infrastructure.Data.Repositories
{
    internal class PriceRepository(MainContext context) : Repository<Price>(context), IPriceRepository
    {
        private readonly MainContext _context = context;

        public async Task<Result<Price>> GetByDateAndCodeAsync(DateOnly dateOnly, string code)
        {
            var price = await _context.Prices
                .FirstOrDefaultAsync(mp => mp.Date == dateOnly && mp.SecurityCode == code);
            if (price == null) return CommonErrors.EntityNotFound;
            return price;
        }

        public async Task<Result<List<Price>>> GetBySecurityCodeAsync(string code)
        {
            var prices = await _context.Prices
                .Where(mp => mp.SecurityCode == code)
                .AsNoTracking()
                .OrderBy(mp => mp.Date)
                .ToListAsync();

            return prices;
        }
    }
}
