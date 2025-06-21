using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Exchanges.Commands.UpdateExchangeFromExternalApi
{
    public sealed record UpdateExchangeFromExternalApiCommand(
        string Code) : IRequest<Result>;
}
