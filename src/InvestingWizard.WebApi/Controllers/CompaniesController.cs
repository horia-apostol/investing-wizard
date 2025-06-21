using InvestingWizard.Application.Features.Companies.Commands.AddCompanyFromExternalApi;
using InvestingWizard.Application.Features.Companies.Commands.UpdateCompanyFromExternalApi;
using InvestingWizard.Application.Features.Companies.Queries.GetAllCompaniesByExchangeCode;
using InvestingWizard.Application.Features.Companies.Queries.GetAllCompanyCodes;
using InvestingWizard.Application.Features.Companies.Queries.GetAnalystRatingsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetBalanceSheetByCodeQuery;
using InvestingWizard.Application.Features.Companies.Queries.GetCashFlowByCodeQuery;
using InvestingWizard.Application.Features.Companies.Queries.GetCompanyDataFromExternalApi;
using InvestingWizard.Application.Features.Companies.Queries.GetDividendRateByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetEarningsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetEsgScoresByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetGeneralInformationByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetHighlightsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetHoldersByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetIncomeStatementByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetInsiderTransactionsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetNameByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetOutstandingSharesByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetSharesStatsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetSplitsDividendsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetTechnicalsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetValuationByCode;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvestingWizard.WebUI.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("all/{exchangeCode}")]
        public async Task<IActionResult> GetAllCompaniesByExchangeCode(string exchangeCode)
        {
            var query = new GetAllCompaniesByExchangeCodeQuery(exchangeCode);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("all-codes")]
        public async Task<IActionResult> GetAllCompanyCodes()
        {
            var query = new GetAllCompanyCodesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("name/{code}")]
        public async Task<IActionResult> GetCompanyNameByCode(string code)
        {
            var query = new GetNameByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("dividend-rate/{code}")]
        public async Task<IActionResult> GetCompanyDividendRateByCode(string code)
        {
            var query = new GetDividendRateByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("general-information/{code}")]
        public async Task<IActionResult> GetCompanyGeneralInformationByCode(string code)
        {
            var query = new GetGeneralInformationByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("highlights/{code}")]
        public async Task<IActionResult> GetCompanyHighlightsByCode(string code)
        {
            var query = new GetHighlightsByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("valuation/{code}")]
        public async Task<IActionResult> GetCompanyValuationByCode(string code)
        {
            var query = new GetValuationByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("earnings/{code}")]
        public async Task<IActionResult> GetCompanyEarningsByCode(string code)
        {
            var query = new GetEarningsByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("holders/{code}")]
        public async Task<IActionResult> GetCompanyHoldersByCode(string code)
        {
            var query = new GetHoldersByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("insider-transactions/{code}")]
        public async Task<IActionResult> GetCompanyInsiderTransactionsByCode(string code)
        {
            var query = new GetInsiderTransactionsByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("analyst-ratings/{code}")]
        public async Task<IActionResult> GetCompanyAnalystRatingsByCode(string code)
        {
            var query = new GetAnalystRatingsByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("esg-scores/{code}")]
        public async Task<IActionResult> GetCompanyEsgScoresByCode(string code)
        {
            var query = new GetEsgScoresByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("technicals/{code}")]
        public async Task<IActionResult> GetCompanyTechnicalsByCode(string code)
        {
            var query = new GetTechnicalsByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("shares-stats/{code}")]
        public async Task<IActionResult> GetCompanySharesStatsByCode(string code)
        {
            var query = new GetSharesStatsByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("outstanding-shares/{code}")]
        public async Task<IActionResult> GetCompanyOutstandingSharesByCode(string code)
        {
            var query = new GetOutstandingSharesByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("splits-dividends/{code}")]
        public async Task<IActionResult> GetCompanySplitsDividendsByCode(string code)
        {
            var query = new GetSplitsDividendsByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("financials/income-statement/{code}")]
        public async Task<IActionResult> GetCompanyIncomeStatementByCode(string code)
        {
            var query = new GetIncomeStatementByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("financials/balance-sheet/{code}")]
        public async Task<IActionResult> GetCompanyBalanceSheetByCode(string code)
        {
            var query = new GetBalanceSheetByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("financials/cash-flow/{code}")]
        public async Task<IActionResult> GetCompanyCashFlowByCode(string code)
        {
            var query = new GetCashFlowByCodeQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("external/{code}")]
        public async Task<IActionResult> GetCompanyDataFromExternalApi(string code)
        {
            var query = new GetCompanyDataFromExternalApiQuery(code);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("external/{code}")]
        public async Task<IActionResult> AddCompanyFromExternalApi(string code)
        {
            var command = new AddCompanyFromExternalApiCommand(code);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("external/{code}")]
        public async Task<IActionResult> UpdateCompanyFromExternalApi(string code)
        {
            var command = new UpdateCompanyFromExternalApiCommand(code);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
