using AutoMapper;
using InvestingWizard.Application.Features.Portfolios.Queries.GetDividendById;
using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Domain.Companies;
using InvestingWizard.Domain.Interfaces.Repositories;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetTotalDividendByUserId
{
    internal sealed class GetTotalDividendByUserIdQueryHandler(
        IPortfolioRepository portfolioRepository,
        IDividendOrchestrationService dividendOrchestrationService,
        IMapper mapper)
        : IRequestHandler<GetTotalDividendByUserIdQuery, Result<DividendResponseDto>>
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;
        private readonly IDividendOrchestrationService _dividendOrchestrationService = dividendOrchestrationService;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<DividendResponseDto>> Handle(GetTotalDividendByUserIdQuery request, CancellationToken cancellationToken)
        {
            var portfolios = await _portfolioRepository.GetPortfoliosByUserIdAsync(request.UserId);
            if (portfolios.IsFailure) return CommonErrors.NoEntitiesFound;

            decimal? totalDividend = 0.0m;
            string userCurrencyCode = string.Empty;

            foreach (var portfolio in portfolios.Value)
            {
                var dividendResult = await _dividendOrchestrationService.GetDividendByIdAsync(portfolio.Id);
                if (dividendResult.IsFailure) return dividendResult.Error;
                if (dividendResult.Value is null) return CommonErrors.UnexpectedNullValue;

                if (userCurrencyCode == string.Empty)
                {
                    userCurrencyCode = dividendResult.Value.CurrencyCode;
                }
                var dividendRate = dividendResult.Value;
                totalDividend += dividendRate.Value;
            }

            return _mapper.Map<DividendResponseDto>(new DividendRateResult(totalDividend, userCurrencyCode));
        }
    }
}
