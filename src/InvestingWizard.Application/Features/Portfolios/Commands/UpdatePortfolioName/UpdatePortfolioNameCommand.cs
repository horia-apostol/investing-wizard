using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Commands.UpdatePortfolioName
{
    public sealed record UpdatePortfolioNameCommand(
        Guid Id, string Name) : IRequest<Result>;
}
