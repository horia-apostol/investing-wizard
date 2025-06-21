using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Watchlists;
using InvestingWizard.Domain.Watchlists.Repositories;
using InvestingWizard.Infrastructure.Data.Contexts;
using InvestingWizard.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace InvestingWizard.Infrastructure.Data.Repositories
{
    internal class WatchlistRepository(MainContext context) : Repository<Watchlist>(context), IWatchlistRepository
    {
        private readonly MainContext _context = context;

        public async Task<Result> AddSecurityCodeAsync(Guid id, string securityCode)
        {
            var result = await _context.Watchlists.FindAsync(id);
            if (result == null) return CommonErrors.EntityNotFound;
            result.AddSecurityCode(securityCode);

            _context.Update(result);
            await _context.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<List<Watchlist>>> GetByUserIdAsync(Guid userId)
        {
            var watchlists = await _context.Watchlists.Where(x => x.UserId == userId).ToListAsync();
            if (watchlists == null) return CommonErrors.EntityNotFound;

            var result = watchlists.Select(w =>
            {
                var watchlist = Watchlist.Create(w.UserId, w.Name);
                watchlist.UpdateId(w.Id);
                w.SecurityCodes.ForEach(sc => watchlist.AddSecurityCode(sc));
                return watchlist;

            }).ToList();

            return result;
        }

        public async Task<Result> RemoveSecurityCodeAsync(Guid id, string securityCode)
        {
            var result = await _context.Watchlists.FindAsync(id);
            if (result == null) return CommonErrors.EntityNotFound;
            result.RemoveSecurityCode(securityCode);

            _context.Update(result);
            await _context.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result> UpdateNameAsync(Guid id, string name)
        {
            var result = await _context.Watchlists.FindAsync(id);
            if (result == null) return CommonErrors.EntityNotFound;
            result.UpdateName(name);

            _context.Update(result);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
