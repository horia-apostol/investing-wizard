using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Prices.Commands.AddPricesFromExternalApi
{
    public sealed record AddPricesFromExternalApiCommand(
        string Code) : IRequest<Result>;
}
