using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Companies;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Infrastructure.Data.Contexts;
using InvestingWizard.Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace InvestingWizard.Infrastructure.Data.Repositories
{
    internal class CompanyRepository(MainContext context) : Repository<Company>(context), ICompanyRepository
    {
        private readonly MainContext _context = context;
        public async Task<Result<List<Company>>> GetAllByExchangeCodeAsync(string exchangeCode)
        {
            var companies = await _context.Companies
                .AsNoTracking()
                .Where(c => c.ExchangeCode == exchangeCode)
                .Select(c => new
                {
                    c.Code,
                    c.ExchangeCode,
                    c.Ticker,
                    c.Name
                })
                .ToListAsync();

            if (companies == null) return CommonErrors.EntityNotFound;

            var result = companies.Select(c =>
            {
                var company = Company.Create(c.Code, c.ExchangeCode);
                if (!string.IsNullOrEmpty(c.Name)) company.SetName(c.Name);
                if (!string.IsNullOrEmpty(c.Ticker)) company.SetTicker(c.Ticker);
                return company;

            }).ToList();

            if (result == null) return CommonErrors.UnexpectedNullValue;

            return result;
        }

        public async Task<Result<List<string?>>> GetAllCodesAsync()
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Select(c => c.Code)
                .ToListAsync();

            if (result == null) return CommonErrors.EntityNotFound;

            return result;
        }

        public async Task<Result<Company>> GetAnalystRatingsByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.AnalystRatings
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.AnalystRatings == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetAnalystRatings(result.AnalystRatings);

            return company;
        }

        public async Task<Result<Company>> GetBalanceSheetByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.Financials!.BalanceSheet
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.BalanceSheet == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetBalanceSheet(result.BalanceSheet);

            return company;
        }

        public async Task<Result<Company>> GetCashFlowByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.Financials!.CashFlow
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.CashFlow == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetCashFlow(result.CashFlow);

            return company;
        }

        public async Task<Result<Company>> GetCompanyNameByCodeAsync(string code)
        {
            var result = _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.Name
                })
                .FirstOrDefault();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.Name == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetName(result.Name);

            return company;
        }

        public async Task<Result<Company>> GetEarningsByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.Earnings
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.Earnings == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetEarnings(result.Earnings);

            return company;
        }

        public async Task<Result<Company>> GetEsgScoresByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.EsgScores
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.EsgScores == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetEsgScores(result.EsgScores);

            return company;
        }

        public async Task<Result<Company>> GetGeneralInformationByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.GeneralInformation
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.GeneralInformation == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetGeneralInformation(result.GeneralInformation);

            return company;
        }

        public async Task<Result<Company>> GetHighlightsByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.Highlights
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.Highlights == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetHighlights(result.Highlights);

            return company;
        }

        public async Task<Result<Company>> GetHoldersByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.Holders
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.Holders == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetHolders(result.Holders);

            return company;
        }

        public async Task<Result<Company>> GetIncomeStatementByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.Financials!.IncomeStatement
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.IncomeStatement == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetIncomeStatement(result.IncomeStatement);

            return company;
        }

        public async Task<Result<Company>> GetInsiderTransactionsByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.InsiderTransactions
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.InsiderTransactions == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetInsiderTransactions(result.InsiderTransactions);

            return company;
        }

        public async Task<Result<Company>> GetOutstandingSharesByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.OutstandingShares
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.OutstandingShares == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetOutstandingShares(result.OutstandingShares);

            return company;
        }

        public async Task<Result<Company>> GetSharesStatsByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.SharesStats
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.SharesStats == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetSharesStats(result.SharesStats);

            return company;
        }

        public async Task<Result<Company>> GetSplitsDividendsByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.SplitsDividends
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.SplitsDividends == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetSplitsDividends(result.SplitsDividends);

            return company;
        }

        public async Task<Result<Company>> GetTechnicalsByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.Technicals
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.Technicals == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetTechnicals(result.Technicals);

            return company;
        }

        public async Task<Result<Company>> GetValuationByCodeAsync(string code)
        {
            var result = await _context.Companies
                .AsNoTracking()
                .Where(c => c.Code == code)
                .Select(c => new
                {
                    c.ExchangeCode,
                    c.Valuation
                })
                .FirstOrDefaultAsync();

            if (result == null) return CommonErrors.EntityNotFound;
            if (result.Valuation == null) return CommonErrors.UnexpectedNullValue;

            var company = Company.Create(code, result.ExchangeCode);
            company.SetValuation(result.Valuation);

            return company;
        }
    }
}
