using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Commands.AddPortfolio
{
    public sealed record AddPortfolioCommand(
        Guid UserId, string Name) : IRequest<Result>;
}
