using InvestingWizard.Application.Features.Currencies.Commands.AddCurrency;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvestingWizard.WebUI.Controllers
{
    [ApiController]
    [Route("api/currencies")]

    public class CurrenciesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> AddCurrency(string code, string name, string symbol)
        {
            var command = new AddCurrencyCommand(code, name, symbol);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
