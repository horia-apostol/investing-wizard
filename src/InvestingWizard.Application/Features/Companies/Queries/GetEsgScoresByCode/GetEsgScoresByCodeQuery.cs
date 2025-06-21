using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetEsgScoresByCode
{
    public sealed record GetEsgScoresByCodeQuery(
        string Code) : IRequest<Result<EsgScoresResponseDto>>;
}
