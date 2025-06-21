using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetTechnicalsByCode
{
    public sealed record GetTechnicalsByCodeQuery(
        string Code) : IRequest<Result<TechnicalsResponseDto>>;
}
