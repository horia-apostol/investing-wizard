using AutoMapper;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Prices.Repositories;
using MediatR;
using InvestingWizard.Application.Features.Prices.Queries.GetPricesFromExternalApi;

namespace InvestingWizard.Application.Features.Prices.Queries.GetPricesBySecurityCode
{
    internal sealed class GetPricesBySecurityCodeQueryHandler(IPriceRepository priceRepository, IMapper mapper)
        : IRequestHandler<GetPricesBySecurityCodeQuery, Result<List<PriceResponseDto>>>
    {
        private readonly IPriceRepository _priceRepository = priceRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<List<PriceResponseDto>>> Handle(GetPricesBySecurityCodeQuery request, CancellationToken cancellationToken)
        {
            var marketPrices = await _priceRepository.GetBySecurityCodeAsync(request.SecurityCode);
            if (marketPrices.IsFailure) return CommonErrors.NoEntitiesFound;
            return _mapper.Map<List<PriceResponseDto>>(marketPrices.Value);
        }
    }
}
