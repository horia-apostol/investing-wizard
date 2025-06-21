using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Companies.Queries.GetNameByCode
{
    public sealed record GetNameByCodeQuery(
        string Code ) : IRequest<Result<CompanyNameResponseDto>>;
}
