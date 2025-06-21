using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Commands.AddTransaction
{
    public sealed record AddTransactionCommand(
        Guid PortfolioId,
        DateOnly Date,
        string SecurityCode,
        decimal Units,
        bool BrokerIsResident) : IRequest<Result>;
}
