using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Exchanges.Repositories;
using MediatR;
using InvestingWizard.Application.Shared.Interfaces;

namespace InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeStatusByCode
{
    internal sealed class GetExchangeStatusByCodeQueryHandler(IExchangeRepository exchangeRepository, ITimeZoneService timeZoneService)
        : IRequestHandler<GetExchangeStatusByCodeQuery, Result<ExchangeStatusDto>>
    {
        private readonly IExchangeRepository _exchangeRepository = exchangeRepository;
        private readonly ITimeZoneService _timeZoneService = timeZoneService;

        public async Task<Result<ExchangeStatusDto>> Handle(GetExchangeStatusByCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _exchangeRepository.GetExchangeByCode(request.Code);
            if (result is null)
            {
                return CommonErrors.NoEntitiesFound;
            }

            var exchange = result.Value;
            if (exchange is null) return CommonErrors.UnexpectedNullValue;

            var now = _timeZoneService.GetCurrentTimeInTimeZone(exchange.TimeZone);

            var exchangeStatus = new ExchangeStatusDto
            {
                IsOpen = exchange.IsOpen(now),
                WasOpenToday = exchange.WasOpenToday(now),
                TimeUntilNextOpen = exchange.GetTimeUntilNextOpen(now)
            };

            return exchangeStatus;
        }
    }
}
