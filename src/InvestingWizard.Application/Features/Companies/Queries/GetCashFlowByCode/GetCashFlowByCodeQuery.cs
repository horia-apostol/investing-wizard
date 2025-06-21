using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetCashFlowByCodeQuery
{
    public sealed record GetCashFlowByCodeQuery(
        string Code) : IRequest<Result<CashFlowReportResponseDto>>;
}
