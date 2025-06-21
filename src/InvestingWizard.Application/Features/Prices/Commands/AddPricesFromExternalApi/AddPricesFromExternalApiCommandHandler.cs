using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Prices.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Prices.Commands.AddPricesFromExternalApi
{
    internal sealed class AddPricesFromExternalApiCommandHandler(
        IPriceRepository priceRepository,
        IExternalApiService externalApiService,
        IEntityMapper entityMapper) : IRequestHandler<AddPricesFromExternalApiCommand, Result>
    {
        private readonly IPriceRepository _priceRepository = priceRepository;
        private readonly IExternalApiService _externalApiService = externalApiService;
        private readonly IEntityMapper _entityMapper = entityMapper;

        public async Task<Result> Handle(AddPricesFromExternalApiCommand request, CancellationToken cancellationToken)
        {
            var marketPriceData = await _externalApiService.GetPriceDataAsync(request.Code); 

            if (marketPriceData.IsFailure) return CommonErrors.NoEntitiesFound;
            if (marketPriceData.Value == null) return CommonErrors.UnexpectedNullValue;

            foreach (var price in marketPriceData.Value)
            {
                var marketPrice = _entityMapper.Map(request.Code, price);
                await _priceRepository.AddAsync(marketPrice);
            }
            return Result.Success();
        }
    }
}
