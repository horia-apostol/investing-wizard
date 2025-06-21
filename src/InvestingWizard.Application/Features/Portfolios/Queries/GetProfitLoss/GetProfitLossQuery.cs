using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetProfitLoss
{
    public sealed record GetProfitLossQuery(
        Guid Id, string SecurityCode) : IRequest<Result<ProfitLossResultResponseDto>>;
}
