using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Commands.AddSecurityCode
{
    public sealed record AddSecurityCodeCommand(
        Guid Id, string SecurityCode) : IRequest<Result>;
}
