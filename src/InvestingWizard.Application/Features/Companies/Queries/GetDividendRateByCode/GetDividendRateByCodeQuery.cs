using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Companies.Queries.GetDividendRateByCode
{
    public sealed record GetDividendRateByCodeQuery(
        string Code) : IRequest<Result<DividendRateResponseDto>>;
}
