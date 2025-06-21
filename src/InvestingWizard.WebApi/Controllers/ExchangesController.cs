using InvestingWizard.Application.Features.Exchanges.Commands.AddExchangeFromExternalApi;
using InvestingWizard.Application.Features.Exchanges.Commands.UpdateExchangeFromExternalApi;
using InvestingWizard.Application.Features.Exchanges.Queries.GetAllExchanges;
using InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeByCode;
using InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeDataFromExternalApi;
using InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeStatusByCode;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestingWizard.WebUI.Controllers
{
    [ApiController]
    [Route("api/exchanges")]
    public class ExchangesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("status/{code}")]
        public async Task<IActionResult> GetExchangeStatusByCode(string code)
        {
            var query = new GetExchangeStatusByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("external/")]
        public async Task<IActionResult> AddExchangeFromExternalApi(string code)
        {
            var result = await _mediator.Send(new AddExchangeFromExternalApiCommand(code));
            return Ok(result);
        }

        [HttpPut("external/")]
        public async Task<IActionResult> UpdateExchangeFromExternalApi(string code)
        {
            var result = await _mediator.Send(new UpdateExchangeFromExternalApiCommand(code));
            return Ok(result);
        }

        [HttpGet("external/")]
        public async Task<IActionResult> GetExchangeDataFromExternalApi(string code)
        {
            var result = await _mediator.Send(new GetExchangeDataFromExternalApiQuery(code));
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllExchanges()
        {
            var result = await _mediator.Send(new GetAllExchangesQuery());
            return Ok(result);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetExchangeByCode(string code)
        {
            var result = await _mediator.Send(new GetExchangeByCodeQuery(code));
            return Ok(result);
        }
    }
}
