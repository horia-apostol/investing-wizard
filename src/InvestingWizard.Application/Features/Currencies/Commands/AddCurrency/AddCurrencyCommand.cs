using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Currencies.Commands.AddCurrency
{
    public sealed record AddCurrencyCommand(
        string Code, string Name, string Symbol): IRequest<Result>;
}
