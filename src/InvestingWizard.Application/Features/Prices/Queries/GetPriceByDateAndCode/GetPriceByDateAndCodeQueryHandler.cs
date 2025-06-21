using AutoMapper;
using InvestingWizard.Application.Features.Prices.Queries.GetPricesFromExternalApi;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Prices.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Prices.Queries.GetPriceByDateAndCode
{
    internal sealed class GetPriceByDateAndCodeQueryHandler(IPriceRepository priceRepository, IMapper mapper)
        : IRequestHandler<GetPriceByDateAndCodeQuery, Result<PriceResponseDto>>
    {
        private readonly IPriceRepository _priceRepository = priceRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<PriceResponseDto>> Handle(GetPriceByDateAndCodeQuery request, CancellationToken cancellationToken)
        {
            var marketPrice = await _priceRepository.GetByDateAndCodeAsync(request.DateOnly, request.Code);
            if (marketPrice.IsFailure) return CommonErrors.NoEntitiesFound;
            return _mapper.Map<PriceResponseDto>(marketPrice.Value);
        }
    }
}
