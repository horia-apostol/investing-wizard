using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetAnalystRatingsByCode
{
    public sealed record GetAnalystRatingsByCodeQuery(
               string Code) : IRequest<Result<AnalystRatingsResponseDto>>;
}
