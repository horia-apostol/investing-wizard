using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetAllCompanyCodes
{
    public sealed record GetAllCompanyCodesQuery() 
        : IRequest<Result<CodesResponseDto>>;
}
