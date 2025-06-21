using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetIncomeStatementByCode
{
    public sealed record GetIncomeStatementByCodeQuery(
            string Code) : IRequest<Result<IncomeStatementReportResponseDto>>;
}
