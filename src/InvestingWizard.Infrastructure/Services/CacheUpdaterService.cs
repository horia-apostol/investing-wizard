using AutoMapper;
using InvestingWizard.Application.Features.Companies.Queries.GetAllCompanyCodes;
using InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode;
using InvestingWizard.Application.Shared.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Threading.Tasks;

namespace InvestingWizard.Infrastructure.Services
{
    public class CacheUpdaterService(IServiceProvider serviceProvider) : IHostedService, IDisposable
    {
        private readonly double timeInSeconds = 6000;
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private Timer? _timer;
        private readonly ReaderWriterLockSlim _cacheLock = new();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(UpdateCache, null, TimeSpan.Zero, TimeSpan.FromSeconds(timeInSeconds));
            using (var scope = _serviceProvider.CreateScope())
            {
                var loggingService = scope.ServiceProvider.GetRequiredService<ILoggingService>();
                loggingService.LogInformation("CacheUpdaterService started.");
            }
            return Task.CompletedTask;
        }

        private async void UpdateCache(object? state)
        {
            using var scope = _serviceProvider.CreateScope();
            var loggingService = scope.ServiceProvider.GetRequiredService<ILoggingService>();
            loggingService.LogInformation("Updating cache...");

            var memoryCache = scope.ServiceProvider.GetRequiredService<IMemoryCache>();
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var companyCodesResult = await mediator.Send(new GetAllCompanyCodesQuery());

            if (companyCodesResult.IsSuccess)
            {
                var companyCodes = companyCodesResult.Value?.Codes ?? new List<string>();
                companyCodes.Add("USDRON.FOREX");
                loggingService.LogInformation($"Retrieved {companyCodes.Count} company codes.");

                var externalApiService = scope.ServiceProvider.GetRequiredService<IExternalApiService>();

                foreach (var code in companyCodes)
                {
                    var result = await externalApiService.GetLivePriceAsync(code);

                    if (result.IsSuccess)
                    {
                        var livePrice = mapper.Map<LivePriceResponseDto>(result.Value);

                        _cacheLock.EnterWriteLock();
                        try
                        {
                            if (!memoryCache.TryGetValue(code, out LivePriceResponseDto cachedPrice) || cachedPrice != livePrice)
                            {
                                memoryCache.Set(code, livePrice, TimeSpan.FromSeconds(timeInSeconds));
                                loggingService.LogInformation($"Updated cache for {code}");
                            }
                        }
                        finally
                        {
                            _cacheLock.ExitWriteLock();
                        }
                    }
                    else
                    {
                        loggingService.LogWarning($"Failed to update cache for {code}: {result.Error}");
                    }
                }
            }
            else
            {
                loggingService.LogWarning("Failed to retrieve company codes.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            using (var scope = _serviceProvider.CreateScope())
            {
                var loggingService = scope.ServiceProvider.GetRequiredService<ILoggingService>();
                loggingService.LogInformation("CacheUpdaterService stopped.");
            }
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _cacheLock.Dispose();
        }
    }
}
