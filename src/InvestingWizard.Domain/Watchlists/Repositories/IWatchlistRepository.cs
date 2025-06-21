using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Interfaces.Repositories;

namespace InvestingWizard.Domain.Watchlists.Repositories
{
    public interface IWatchlistRepository : IAsyncRepository<Watchlist>
    {
        Task<Result> UpdateNameAsync(Guid id, string name);
        Task<Result> AddSecurityCodeAsync(Guid id, string securityCode);
        Task<Result> RemoveSecurityCodeAsync(Guid id, string securityCode);
        Task<Result<List<Watchlist>>> GetByUserIdAsync(Guid userId);
    }
}
