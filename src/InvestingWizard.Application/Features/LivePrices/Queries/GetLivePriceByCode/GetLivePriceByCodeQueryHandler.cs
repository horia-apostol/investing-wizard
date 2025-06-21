using AutoMapper;
using MediatR;
using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode
{
    internal sealed class GetLivePriceByCodeQueryHandler(IExternalApiService externalApiService, IMapper mapper)
        : IRequestHandler<GetLivePriceByCodeQuery, Result<LivePriceResponseDto>>
    {
        private readonly IExternalApiService _externalApiService = externalApiService;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<LivePriceResponseDto>> Handle(GetLivePriceByCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _externalApiService.GetLivePriceAsync(request.Code);
            var livePrice = _mapper.Map<LivePriceResponseDto>(result.Value);

            if (livePrice is null) return CommonErrors.UnexpectedNullValue;

            return livePrice;
        }
    }
}
