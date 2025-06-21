using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Prices;
using MediatR;


namespace InvestingWizard.Application.Features.Prices.Commands.AddPrice
{
    public sealed record AddPriceCommand(
        Price Price) : IRequest<Result>;
}
