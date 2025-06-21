using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Commands.DeletePortfolio
{
    public sealed record DeletePortfolioCommand(
        Guid Id) : IRequest<Result>;
}
