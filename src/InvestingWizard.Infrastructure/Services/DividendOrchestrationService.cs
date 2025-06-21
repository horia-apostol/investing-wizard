using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Domain.Companies;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Domain.Interfaces.Repositories;
using InvestingWizard.Identity.Services;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Infrastructure.Services
{
    public class DividendOrchestrationService(
        IPortfolioRepository portfolioRepository,
        ICompanyRepository companyRepository,
        ApplicationUserManager userManager,
        ICachedPricesService cachedPricesService) 
        : IDividendOrchestrationService
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly ApplicationUserManager _userManager = userManager;
        private readonly ICachedPricesService _cachedPricesService = cachedPricesService;

        public async Task<Result<DividendRateResult>> GetDividendByIdAsync(Guid id)
        {
            var portfolio = await _portfolioRepository.FindByIdAsync(id);
            if (portfolio.IsFailure) return portfolio.Error;
            if (portfolio.Value is null) return CommonErrors.UnexpectedNullValue;

            var user = await _userManager.FindByIdAsync(portfolio.Value.UserId.ToString());
            if (user is null) return CommonErrors.EntityNotFound;
            if (user.PreferredCurrencyCode is null) return CommonErrors.UnexpectedNullValue;
            var userCurrencyCode = user.PreferredCurrencyCode;

            decimal totalDividend = 0.0m;

            var portfolioEntries = portfolio.Value.PortfolioEntries
                .ToDictionary(entry => entry.SecurityCode, entry => entry.TotalUnits);
            foreach (var entry in portfolioEntries)
            {
                var dividendResult = await _companyRepository.GetSplitsDividendsByCodeAsync(entry.Key);
                if (dividendResult.IsFailure) return dividendResult.Error;
                if (dividendResult.Value is null) return CommonErrors.EntityNotFound;
                if (dividendResult.Value.SplitsDividends is null) return CommonErrors.UnexpectedNullValue;
                if (dividendResult.Value.SplitsDividends.ForwardAnnualDividendRate is null) return CommonErrors.UnexpectedNullValue;

                var dividendValue = dividendResult.Value.SplitsDividends.ForwardAnnualDividendRate;
                
                var currencyResult = await _companyRepository.GetGeneralInformationByCodeAsync(entry.Key);
                if (currencyResult.IsFailure) return currencyResult.Error;
                if (currencyResult.Value is null) return CommonErrors.EntityNotFound;
                if (currencyResult.Value.GeneralInformation is null) return CommonErrors.UnexpectedNullValue;
                if (currencyResult.Value.GeneralInformation.CurrencyCode is null) return CommonErrors.UnexpectedNullValue;

                var currencyCode = currencyResult.Value.GeneralInformation.CurrencyCode;

                if (currencyCode != userCurrencyCode)
                {
                    var priceCode = $"{currencyCode}{userCurrencyCode}.FOREX";
                    var result = _cachedPricesService.GetCachedPriceAsync(priceCode);
                    if (result.IsFailure) return result.Error;
                    if (result.Value is null) return CommonErrors.UnexpectedNullValue;
                    var exchangeRate = result.Value.Close;
                    dividendValue *= exchangeRate;
                }
                totalDividend += (decimal)(dividendValue * entry.Value);
            }
            return new DividendRateResult(totalDividend, userCurrencyCode);
        }
    }
}
