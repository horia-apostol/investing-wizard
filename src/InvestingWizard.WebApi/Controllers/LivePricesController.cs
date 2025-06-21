using Microsoft.AspNetCore.Mvc;
using InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode;
using MediatR;

namespace InvestingWizard.WebUI.Controllers
{
    [ApiController]
    [Route("api/live-prices")]
    public class LivePricesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet("{code}")]
        public async Task<IActionResult> GetLivePriceByCode(string code)
        {
            var query = new GetLivePriceByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
