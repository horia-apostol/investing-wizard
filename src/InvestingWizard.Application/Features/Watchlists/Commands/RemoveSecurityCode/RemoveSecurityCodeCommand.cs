using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Commands.RemoveSecurityCode
{
    public sealed record RemoveSecurityCodeCommand(
        Guid Id, string SecurityCode) : IRequest<Result>;
}
