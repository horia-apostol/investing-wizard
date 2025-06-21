using AutoMapper;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Interfaces.Repositories;
using InvestingWizard.Domain.Portfolios.ProfitLossResult;
using MediatR;
using InvestingWizard.Application.Shared.Interfaces;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetProfitLoss
{
    internal sealed class GetProfitLossQueryHandler(IPortfolioRepository portfolioRepository, ICachedPricesService cachedPricesService, IMapper mapper)
        : IRequestHandler<GetProfitLossQuery, Result<ProfitLossResultResponseDto>>
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;
        private readonly ICachedPricesService _cachedPricesService = cachedPricesService;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<ProfitLossResultResponseDto>> Handle(GetProfitLossQuery request, CancellationToken cancellationToken)
        {
            var result = await _portfolioRepository.FindByIdAsync(request.Id);
            if (result.IsFailure) return CommonErrors.EntityNotFound;
            if (result.Value is null) return CommonErrors.EntityNotFound;

            var portfolioEntry = result.Value.PortfolioEntries.FirstOrDefault(pe => pe.SecurityCode == request.SecurityCode);
            if (portfolioEntry is null) return CommonErrors.EntityNotFound;

            decimal currentPrice = 0;
            var cachedPriceResult = _cachedPricesService.GetCachedPriceAsync(request.SecurityCode);
            if (cachedPriceResult.IsFailure) return cachedPriceResult.Error;
            if (cachedPriceResult.Value is null) return CommonErrors.EntityNotFound;
            currentPrice = cachedPriceResult.Value.Close;
            return _mapper.Map<ProfitLossResultResponseDto>(new ProfitLossResult(portfolioEntry.CalculateProfitLoss(currentPrice)));
        }
    }
}
