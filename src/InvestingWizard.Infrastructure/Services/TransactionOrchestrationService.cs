using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Interfaces.Repositories;
using InvestingWizard.Domain.Portfolios;
using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Exchanges.Repositories;
using InvestingWizard.Domain.Prices.Repositories;
using InvestingWizard.Identity.Services;

namespace InvestingWizard.Infrastructure.Services
{
    public class TransactionOrchestrationService(
        IPortfolioRepository portfolioRepository,
        IPriceRepository priceRepository,
        IExchangeRepository exchangeRepository,
        ApplicationUserManager userManager,
        ICachedPricesService cachedPricesService) : ITransactionOrchestrationService
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;
        private readonly IPriceRepository _priceRepository = priceRepository;
        private readonly IExchangeRepository _exchangeRepository = exchangeRepository;
        private readonly ApplicationUserManager _userManager = userManager;
        private readonly ICachedPricesService _cachedPricesService = cachedPricesService;

        public async Task<Result> AddTransactionAsync(Guid portfolioId, DateOnly date, string securityCode, decimal units, bool brokerIsResident)
        {
            decimal unitPrice;
            if (date == DateOnly.FromDateTime(DateTime.UtcNow))
            {
                var result = _cachedPricesService.GetCachedPriceAsync(securityCode);
                if (result.IsFailure) return result.Error;
                if (result.Value is null) return CommonErrors.UnexpectedNullValue;
                unitPrice = result.Value.Close;
            }
            else
            {
                var result = await _priceRepository.GetByDateAndCodeAsync(date, securityCode);
                if (result.IsFailure) return result.Error;
                if (result.Value is null) return CommonErrors.EntityNotFound;
                unitPrice = result.Value.AdjustedClose;
            }

            var transactionExchangeCode = await _exchangeRepository.GetExchangeByCode(ExtractExchangeCode(securityCode));
            if (transactionExchangeCode is null) return CommonErrors.EntityNotFound;
            if (transactionExchangeCode.Value is null) return CommonErrors.UnexpectedNullValue;
            var transactionCurrencyCode = transactionExchangeCode.Value.CurrencyCode;

            var portfolio = await _portfolioRepository.FindByIdAsync(portfolioId);
            if (portfolio is null) return CommonErrors.EntityNotFound;
            if (portfolio.Value is null) return CommonErrors.UnexpectedNullValue;

            var user = await _userManager.FindByIdAsync(portfolio.Value.UserId.ToString());
            if (user is null) return CommonErrors.EntityNotFound;
            if (user.PreferredCurrencyCode is null) return CommonErrors.UnexpectedNullValue;
            var userCurrencyCode = user.PreferredCurrencyCode;

            var amountInTransactionCurrency = unitPrice * units;
            var amountInUserCurrency = amountInTransactionCurrency;

            if (transactionCurrencyCode != userCurrencyCode)
            {
                var priceCode = $"{transactionCurrencyCode}{userCurrencyCode}.FOREX";
                decimal exchangeRate;
                if (date == DateOnly.FromDateTime(DateTime.UtcNow))
                {
                    var result = _cachedPricesService.GetCachedPriceAsync(priceCode);
                    if (result.IsFailure) return result.Error;
                    if (result.Value is null) return CommonErrors.UnexpectedNullValue;
                    exchangeRate = result.Value.Close;
                }
                else
                {
                    var result = await _priceRepository.GetByDateAndCodeAsync(date, priceCode);
                    if (result.IsFailure) return result.Error;
                    if (result.Value is null) return CommonErrors.EntityNotFound;
                    exchangeRate = result.Value.AdjustedClose;
                }
                amountInUserCurrency *= exchangeRate;
            }

            var transaction = Transaction.Create(
                date,
                unitPrice,
                units,
                transactionCurrencyCode,
                userCurrencyCode,
                securityCode,
                amountInUserCurrency,
                brokerIsResident
            );

            return await _portfolioRepository.AddTransactionAsync(portfolioId, transaction);
        }
        private static string ExtractExchangeCode(string code)
        {
            return code.Split('.')[1];
        }
    }
}
