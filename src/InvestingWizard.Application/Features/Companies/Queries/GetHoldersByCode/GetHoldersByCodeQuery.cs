using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetHoldersByCode
{
    public sealed record GetHoldersByCodeQuery(
        string Code) : IRequest<Result<HoldersResponseDto>>;
}
