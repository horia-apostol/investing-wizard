using InvestingWizard.Shared.Common;
using MediatR;
using System;

namespace InvestingWizard.Application.Features.Portfolios.Commands.ApproveSuggestion
{
    public sealed record ApproveSuggestionCommand(
        Guid PortfolioId,
        Guid TransactionId,
        string SecurityCode,
        decimal UnitsToSell,
        bool IsPartialClose,
        decimal UnitPrice,
        string TransactionCurrencyCode,
        string UserCurrencyCode,
        decimal AmountInUserCurrency,
        bool BrokerIsResident) : IRequest<Result>;
}
