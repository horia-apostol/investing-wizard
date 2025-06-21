using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Interfaces.Repositories;
using InvestingWizard.Domain.Portfolios;
using InvestingWizard.Domain.Portfolios.ProfitLossResult;
using InvestingWizard.Infrastructure.Data.Contexts;
using InvestingWizard.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace InvestingWizard.Infrastructure.Data.Repositories
{
    internal class PortfolioRepository(MainContext context) : Repository<Portfolio>(context), IPortfolioRepository
    {
        private readonly MainContext _context = context;
        public async Task<Result> AddTransactionAsync(Guid id, Transaction transaction)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null) return CommonErrors.EntityNotFound;

            portfolio.AddTransaction(transaction);
            _context.Portfolios.Update(portfolio);

            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result<ProfitLossResult>> CalculateProfitLossAsync(Guid id, string securityCode, decimal currentPrice)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null) return CommonErrors.EntityNotFound;

            var portfolioEntry = portfolio.PortfolioEntries.FirstOrDefault(pe => pe.SecurityCode == securityCode);
            if (portfolioEntry == null) return CommonErrors.EntityNotFound;

            var profitLoss = portfolioEntry.CalculateProfitLoss(currentPrice);
            return new ProfitLossResult(profitLoss);
        }

        public async Task<Result> CloseTransactionPartiallyAsync(Guid portfolioId, Guid transactionId, decimal quantity)
        {
            var portfolio = await _context.Portfolios.FindAsync(portfolioId);
            if (portfolio == null) return CommonErrors.EntityNotFound;

            var transaction = portfolio.Transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction == null) return CommonErrors.EntityNotFound;

            portfolio.CloseTransactionPartially(transactionId, quantity);

            _context.Portfolios.Update(portfolio);
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result<List<Portfolio>>> GetPortfoliosByUserIdAsync(Guid userId)
        {
            var portfolios = await _context.Portfolios
                .Where(p => p.UserId == userId)
                .ToListAsync();

            if (portfolios == null) return CommonErrors.EntityNotFound;
            return portfolios;
        }

        public async Task<Result> RemoveTransactionAsync(Guid id, Guid transactionId)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null) return CommonErrors.EntityNotFound;

            var transaction = portfolio.Transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction == null) return CommonErrors.EntityNotFound;

            portfolio.RemoveTransaction(transaction);

            _context.Portfolios.Update(portfolio);
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> UpdatePortfolioNameAsync(Guid id, string newName)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null) return CommonErrors.EntityNotFound;

            portfolio.UpdateName(newName);
            _context.Update(portfolio);

            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
