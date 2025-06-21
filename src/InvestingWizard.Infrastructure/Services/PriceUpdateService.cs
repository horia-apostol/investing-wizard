using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Domain.Exchanges.Repositories;
using InvestingWizard.Domain.Prices.Repositories;
using InvestingWizard.Domain.Prices;
using InvestingWizard.Domain.Companies.Repositories;

namespace InvestingWizard.Infrastructure.Services
{
    public class PriceUpdateService(
        ICachedPricesService cachedPricesService,
        IExchangeRepository exchangeRepository,
        IPriceRepository priceRepository,
        ITimeZoneService timeZoneService,
        ICompanyRepository companyRepository) : IPriceUpdateService
    {
        private readonly ICachedPricesService _cachedPricesService = cachedPricesService;
        private readonly IExchangeRepository _exchangeRepository = exchangeRepository;
        private readonly IPriceRepository _priceRepository = priceRepository;
        private readonly ITimeZoneService _timeZoneService = timeZoneService;
        private readonly ICompanyRepository _companyRepository = companyRepository;

        public async Task UpdatePricesAsync()
        {
            var exchanges = await _exchangeRepository.GetAllAsync();

            foreach (var exchange in exchanges.Value)
            {
                var now = _timeZoneService.GetCurrentTimeInTimeZone(exchange.TimeZone);
                if (exchange.WasOpenToday(now) && !exchange.IsOpen(now))
                {
                    var securityCodes = _companyRepository.GetAllCodesAsync();

                    foreach (var securityCode in securityCodes.Result.Value)
                    {
                        var cachedPrice = _cachedPricesService.GetCachedPriceAsync(securityCode);
                        var newPrice = Price.Create(
                            securityCode, 
                            DateOnly.FromDateTime(now), 
                            cachedPrice.Value.Open,
                            cachedPrice.Value.High,
                            cachedPrice.Value.Low,
                            cachedPrice.Value.Close,
                            cachedPrice.Value.Volume,
                            cachedPrice.Value.Close);

                        await _priceRepository.AddAsync(newPrice);
                    }
                }
            }
        }
    }
}
