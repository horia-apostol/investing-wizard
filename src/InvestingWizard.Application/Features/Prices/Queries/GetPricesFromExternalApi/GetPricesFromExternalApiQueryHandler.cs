using AutoMapper;
using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using MediatR;

namespace InvestingWizard.Application.Features.Prices.Queries.GetPricesFromExternalApi
{
    internal sealed class GetPricesFromExternalApiQueryHandler(IExternalApiService externalApiService, IEntityMapper entityMapper, IMapper mapper)
        : IRequestHandler<GetPricesFromExternalApiQuery, Result<List<PriceResponseDto>>>
    {
        private readonly IExternalApiService _externalApiService = externalApiService;
        private readonly IEntityMapper _entityMapper = entityMapper;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<List<PriceResponseDto>>> Handle(GetPricesFromExternalApiQuery request, CancellationToken cancellationToken)
        {
            var marketPriceData = await _externalApiService.GetPriceDataAsync(request.Code);
            if (marketPriceData.IsFailure) return CommonErrors.NoEntitiesFound;
            var marketPrices = marketPriceData.Value!.Select(price =>
            {
                var marketPrice = _entityMapper.Map(request.Code, price);
                return marketPrice;
            }).ToList();
            return _mapper.Map<List<PriceResponseDto>>(marketPrices);
        }
    }
}