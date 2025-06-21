using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetValuationByCode
{
    public sealed record GetValuationByCodeQuery(
        string Code) : IRequest<Result<ValuationResponseDto>>;
}
