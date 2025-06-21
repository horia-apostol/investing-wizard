using InvestingWizard.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestingWizard.WebUI.Controllers
{
    [ApiController]
    [Route("api/live-prices-cache")]
    public class LivePricesCachedController(ICachedPricesService cachedPricesService, IPriceUpdateService priceUpdateService) : ControllerBase
    {
        private readonly ICachedPricesService _cachedPricesService = cachedPricesService;
        private readonly IPriceUpdateService _priceUpdateService = priceUpdateService;

        [HttpGet("{code}")]
        public IActionResult GetLivePriceByCode(string code)
        {
            var result = _cachedPricesService.GetCachedPriceAsync(code);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePricesAsync()
        {
            await _priceUpdateService.UpdatePricesAsync();
            return Ok();
        }
    }
}
