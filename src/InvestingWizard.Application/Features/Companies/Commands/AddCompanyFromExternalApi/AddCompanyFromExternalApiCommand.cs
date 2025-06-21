using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Commands.AddCompanyFromExternalApi
{
    public sealed record AddCompanyFromExternalApiCommand(
        string Code) : IRequest<Result>;
}
