using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Application.Shared.ExternalDtos.Companies;

namespace InvestingWizard.Application.Features.Companies.Queries.GetCompanyDataFromExternalApi
{
    public sealed record GetCompanyDataFromExternalApiQuery(
        string Code) : IRequest<Result<CompanyExternalDto>>;
}
