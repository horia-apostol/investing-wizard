using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Portfolios;
using InvestingWizard.Domain.Portfolios.ProfitLossResult;

namespace InvestingWizard.Domain.Interfaces.Repositories
{
    public interface IPortfolioRepository : IAsyncRepository<Portfolio>
    {
        Task<Result<List<Portfolio>>> GetPortfoliosByUserIdAsync(Guid userId);
        Task<Result> AddTransactionAsync(Guid id, Transaction transaction);
        Task<Result> RemoveTransactionAsync(Guid id, Guid transactionId);
        Task<Result> UpdatePortfolioNameAsync(Guid id, string newName);
        Task<Result<ProfitLossResult>> CalculateProfitLossAsync(Guid id, string securityCode, decimal currentPrice);
        Task<Result> CloseTransactionPartiallyAsync(Guid portfolioId, Guid transactionId, decimal quantity);
    }
}
