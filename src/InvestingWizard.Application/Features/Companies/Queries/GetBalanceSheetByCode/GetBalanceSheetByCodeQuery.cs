using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetBalanceSheetByCodeQuery
{
    public sealed record GetBalanceSheetByCodeQuery(
        string Code) : IRequest<Result<BalanceSheetReportResponseDto>>;
}
