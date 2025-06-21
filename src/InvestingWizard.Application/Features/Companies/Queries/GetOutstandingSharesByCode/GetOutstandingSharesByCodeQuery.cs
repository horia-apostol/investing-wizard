using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetOutstandingSharesByCode
{
    public sealed record GetOutstandingSharesByCodeQuery(
        string Code) : IRequest<Result<OutstandingSharesResponseDto>>;
}
