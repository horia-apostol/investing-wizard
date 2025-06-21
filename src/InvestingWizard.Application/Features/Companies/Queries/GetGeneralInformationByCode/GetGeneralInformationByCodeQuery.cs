using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetGeneralInformationByCode
{
    public sealed record GetGeneralInformationByCodeQuery(
        string Code ) : IRequest<Result<GeneralInformationResponseDto>>;
}
