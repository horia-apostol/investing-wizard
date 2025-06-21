using InvestingWizard.Application.Features.Portfolios.Commands.AddPortfolio;
using InvestingWizard.Application.Features.Portfolios.Commands.AddTransaction;
using InvestingWizard.Application.Features.Portfolios.Commands.ApproveSuggestion;
using InvestingWizard.Application.Features.Portfolios.Commands.CloseTransaction;
using InvestingWizard.Application.Features.Portfolios.Commands.CloseTransactionPartially;
using InvestingWizard.Application.Features.Portfolios.Commands.DeletePortfolio;
using InvestingWizard.Application.Features.Portfolios.Commands.UpdatePortfolioName;
using InvestingWizard.Application.Features.Portfolios.Queries.GetDividendById;
using InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioById;
using InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioEntriesById;
using InvestingWizard.Application.Features.Portfolios.Queries.GetPortfoliosByUserId;
using InvestingWizard.Application.Features.Portfolios.Queries.GetProfitLoss;
using InvestingWizard.Application.Features.Portfolios.Queries.GetTotalDividendByUserId;
using InvestingWizard.Application.Features.Portfolios.Queries.GetTransactionsById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestingWizard.WebUI.Controllers
{
    [ApiController]
    [Route("api/portfolios")]
    public class PortfoliosController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> AddPortfolio([FromBody] AddPortfolioCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("open-transaction")]
        public async Task<IActionResult> AddTransaction([FromBody] AddTransactionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{Id}/name")]
        public async Task<IActionResult> UpdatePortfolioName(Guid Id, string Name)
        {
            var command = new UpdatePortfolioNameCommand(Id, Name);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePortfolio(Guid Id)
        {
            var command = new DeletePortfolioCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("close-transaction")]
        public async Task<IActionResult> CloseTransaction(Guid portfolioId, Guid transactionId)
        {
            var command = new CloseTransactionCommand(portfolioId, transactionId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("close-transaction-partially")]
        public async Task<IActionResult> CloseTransactionPartially(Guid portfolioId, Guid transactionId, decimal quantity)
        {
            var command = new CloseTransactionPartiallyCommand(portfolioId, transactionId, quantity);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("all/{UserId}")]
        public async Task<IActionResult> GetPortfoliosByUserId(Guid UserId)
        {
            var command = new GetPortfoliosByUserIdQuery(UserId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPortfolioById(Guid Id)
        {
            var command = new GetPortfolioByIdQuery(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{Id}/dividend")]
        public async Task<IActionResult> GetPortfolioDividend(Guid Id)
        {
            var command = new GetDividendByIdQuery(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("total-dividend/{UserId}")]
        public async Task<IActionResult> GetTotalDividendByUserId(Guid UserId)
        {
            var command = new GetTotalDividendByUserIdQuery(UserId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{Id}/profit-loss/{SecurityCode}")]
        public async Task<IActionResult> GetProfitLoss(Guid Id, string SecurityCode)
        {
            var command = new GetProfitLossQuery(Id, SecurityCode);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{Id}/entries")]
        public async Task<IActionResult> GetPortfolioEntries(Guid Id)
        {
            var command = new GetPortfolioEntriesByIdQuery(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{Id}/transactions")]
        public async Task<IActionResult> GetPortfolioTransactions(Guid Id)
        {
            var command = new GetPortfolioTransactionsByIdQuery(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("approve-suggestion")]
        public async Task<IActionResult> ApproveSuggestio([FromBody] ApproveSuggestionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
