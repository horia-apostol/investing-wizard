using AutoMapper;
using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using MediatR;

namespace InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeDataFromExternalApi
{
    internal sealed class GetExchangeDataFromExternalApiQueryHandler(IExternalApiService externalApiService, IEntityMapper entityMapper, IMapper mapper)
        : IRequestHandler<GetExchangeDataFromExternalApiQuery, Result<ExchangeDataResponseDto>>
    {
        private readonly IExternalApiService _externalApiService = externalApiService;
        private readonly IEntityMapper _entityMapper = entityMapper;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<ExchangeDataResponseDto>> Handle(GetExchangeDataFromExternalApiQuery request, CancellationToken cancellationToken)
        {
            var exchange = await _externalApiService.GetExchangeDataAsync(request.Code);
            if (exchange.IsFailure) return exchange.Error;
            if (exchange.Value == null) return CommonErrors.UnexpectedNullValue;
            var newExchange = _entityMapper.Map(request.Code, exchange.Value);
            return _mapper.Map<ExchangeDataResponseDto>(newExchange);
        }
    }

}
