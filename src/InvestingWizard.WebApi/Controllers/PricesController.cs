using AutoMapper;
using InvestingWizard.Application.Features.Prices.Commands.AddPrice;
using InvestingWizard.Application.Features.Prices.Commands.AddPricesFromExternalApi;
using InvestingWizard.Application.Features.Prices.Queries.GetPriceByDateAndCode;
using InvestingWizard.Application.Features.Prices.Queries.GetPricesBySecurityCode;
using InvestingWizard.Application.Features.Prices.Queries.GetPricesForChartBySecurityCode;
using InvestingWizard.Application.Features.Prices.Queries.GetPricesFromExternalApi;
using InvestingWizard.Domain.Prices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvestingWizard.WebUI.Controllers
{
    [ApiController]
    [Route("api/prices")]
    public class PricesController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpGet("{code}")]
        public async Task<IActionResult> GetPricesBySecurityCode(string code)
        {
            var query = new GetPricesBySecurityCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{code}/{date}")]
        public async Task<IActionResult> GetPriceByDateAndCode(string code, DateOnly date)
        {
            var query = new GetPriceByDateAndCodeQuery(date, code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddPrice([FromBody] AddPriceRequestDto requestDto)
        {
            var price = _mapper.Map<Price>(requestDto);
            var command = new AddPriceCommand(price);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("chart/{code}")]
        public async Task<IActionResult> GetPricesForChartBySecurityCode(string code)
        {
            var query = new GetPricesForChartBySecurityCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("external/{code}")]
        public async Task<IActionResult> AddPricesFromExternalApi(string code)
        {
            var command = new AddPricesFromExternalApiCommand(code);
            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [HttpGet("external/{code}")]
        public async Task<IActionResult> GetPricesFromExternalApi(string code)
        {
            var query = new GetPricesFromExternalApiQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
