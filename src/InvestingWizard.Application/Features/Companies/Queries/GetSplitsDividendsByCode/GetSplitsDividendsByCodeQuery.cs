using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetSplitsDividendsByCode
{
    public sealed record GetSplitsDividendsByCodeQuery(
        string Code) : IRequest<Result<SplitsDividendsResponseDto>>;
}
