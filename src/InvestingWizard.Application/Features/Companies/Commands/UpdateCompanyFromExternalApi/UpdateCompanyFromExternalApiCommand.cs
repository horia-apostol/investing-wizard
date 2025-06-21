using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Commands.UpdateCompanyFromExternalApi
{
    public sealed record UpdateCompanyFromExternalApiCommand(
               string Code) : IRequest<Result>;
}
