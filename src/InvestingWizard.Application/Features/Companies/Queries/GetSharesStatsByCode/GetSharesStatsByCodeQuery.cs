using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetSharesStatsByCode
{
    public sealed record GetSharesStatsByCodeQuery(
        string Code) : IRequest<Result<SharesStatsResponseDto>>;
}
