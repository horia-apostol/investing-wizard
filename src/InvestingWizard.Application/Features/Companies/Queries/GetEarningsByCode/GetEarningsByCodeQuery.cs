using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetEarningsByCode
{
    public sealed record GetEarningsByCodeQuery(
        string Code) : IRequest<Result<EarningsResponseDto>>;
}
