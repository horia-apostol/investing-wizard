using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Interfaces.Repositories;

namespace InvestingWizard.Domain.Companies.Repositories
{
    public interface ICompanyRepository : IAsyncRepository<Company>
    {
        Task<Result<Company>> GetCompanyNameByCodeAsync(string code);
        Task<Result<Company>> GetGeneralInformationByCodeAsync(string code);
        Task<Result<Company>> GetHighlightsByCodeAsync(string code);
        Task<Result<Company>> GetValuationByCodeAsync(string code);
        Task<Result<Company>> GetSharesStatsByCodeAsync(string code);
        Task<Result<Company>> GetTechnicalsByCodeAsync(string code);
        Task<Result<Company>> GetSplitsDividendsByCodeAsync(string code);
        Task<Result<Company>> GetAnalystRatingsByCodeAsync(string code);
        Task<Result<Company>> GetHoldersByCodeAsync(string code);
        Task<Result<Company>> GetInsiderTransactionsByCodeAsync(string code);
        Task<Result<Company>> GetEsgScoresByCodeAsync(string code);
        Task<Result<Company>> GetOutstandingSharesByCodeAsync(string code);
        Task<Result<Company>> GetEarningsByCodeAsync(string code);
        Task<Result<Company>> GetIncomeStatementByCodeAsync(string code);
        Task<Result<Company>> GetBalanceSheetByCodeAsync(string code);
        Task<Result<Company>> GetCashFlowByCodeAsync(string code);
        Task<Result<List<Company>>> GetAllByExchangeCodeAsync(string exchangeCode);
        Task<Result<List<string?>>> GetAllCodesAsync();
    }
}