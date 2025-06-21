using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeDataFromExternalApi
{
    public sealed record GetExchangeDataFromExternalApiQuery(
        string Code) : IRequest<Result<ExchangeDataResponseDto>>;
}
