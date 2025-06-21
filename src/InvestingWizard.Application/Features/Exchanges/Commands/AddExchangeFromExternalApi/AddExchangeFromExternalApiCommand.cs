using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Exchanges.Commands.AddExchangeFromExternalApi
{
    public sealed record AddExchangeFromExternalApiCommand(
        string Code) : IRequest<Result>;
}
