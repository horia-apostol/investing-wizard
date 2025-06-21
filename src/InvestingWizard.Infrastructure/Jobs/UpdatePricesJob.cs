using InvestingWizard.Application.Shared.Interfaces;
using Quartz;

namespace InvestingWizard.Infrastructure.Jobs
{
    [DisallowConcurrentExecution]
    public class UpdatePricesJob(IPriceUpdateService priceUpdateService) : IJob
    {
        private readonly IPriceUpdateService _priceUpdateService = priceUpdateService;
        public async Task Execute(IJobExecutionContext context)
        {
            await _priceUpdateService.UpdatePricesAsync();
        }
    }
}
