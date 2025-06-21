using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetHighlightsByCode
{
    public sealed record GetHighlightsByCodeQuery(
        string Code) : IRequest<Result<HighlightsResponseDto>>;
}
