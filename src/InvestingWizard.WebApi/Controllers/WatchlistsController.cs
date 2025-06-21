using InvestingWizard.Application.Features.Watchlists.Commands.AddSecurityCode;
using InvestingWizard.Application.Features.Watchlists.Commands.AddWatchlist;
using InvestingWizard.Application.Features.Watchlists.Commands.DeleteWatchlist;
using InvestingWizard.Application.Features.Watchlists.Commands.RemoveSecurityCode;
using InvestingWizard.Application.Features.Watchlists.Commands.UpdateWatchlistName;
using InvestingWizard.Application.Features.Watchlists.Queries.GetWatchlistById;
using InvestingWizard.Application.Features.Watchlists.Queries.GetWatchlistsByUserId;
using InvestingWizard.Shared.Dtos.RequestDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvestingWizard.WebUI.Controllers
{
    [ApiController]
    [Route("api/watchlists")]

    public class WatchlistsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        [HttpPost]
        public async Task<IActionResult> AddWatchlist([FromBody] AddWatchlistRequestDto request)
        {
            var result = await _mediator.Send(new AddWatchlistCommand(request.UserId, request.Name));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWatchlist(Guid id, [FromBody] UpdateWatchlistNameRequestDto request)
        {
            var command = new UpdateWatchlistNameCommand(id, request.Name);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatchlist(Guid id)
        {
            var command = new DeleteWatchlistCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}/add-security/{securityCode}")]
        public async Task<IActionResult> AddSecurityCode(Guid id, string securityCode)
        {
            var command = new AddSecurityCodeCommand(id, securityCode);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}/remove-security/{securityCode}")]
        public async Task<IActionResult> RemoveSecurityCode(Guid id, string securityCode)
        {
            var command = new RemoveSecurityCodeCommand(id, securityCode);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWatchlist(Guid id)
        {
            var query = new GetWatchlistByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetWatchlists(string userId)
        {
            var query = new GetWatchlistsByUserIdQuery(new Guid(userId));
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}