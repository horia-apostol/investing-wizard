using InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode;
using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace InvestingWizard.Infrastructure.Services
{
    public class CachedPricesService(IMemoryCache memoryCache, ILoggingService loggingService) : ICachedPricesService
    {
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly ILoggingService _loggingService = loggingService;
        private readonly ReaderWriterLockSlim _cacheLock = new();
        public Result<LivePriceResponseDto> GetCachedPriceAsync(string securityCode)
        {
            _cacheLock.EnterReadLock();
            try
            {
                if (_memoryCache.TryGetValue(securityCode, out LivePriceResponseDto cachedPrice))
                {
                    _loggingService.LogInformation($"Cache hit for {securityCode}");
                    if (cachedPrice is null) return CommonErrors.UnexpectedNullValue;
                    return cachedPrice;
                }
            }
            finally
            {
                _cacheLock.ExitReadLock();
            }
            _loggingService.LogWarning($"Cache miss for {securityCode}");
            return CommonErrors.UnexpectedNullValue;
        }
    }
}
