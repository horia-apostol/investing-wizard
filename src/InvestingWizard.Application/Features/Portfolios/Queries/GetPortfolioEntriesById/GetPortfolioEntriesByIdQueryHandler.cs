using AutoMapper;
using InvestingWizard.Domain.Interfaces.Repositories;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioEntriesById
{
    internal sealed class GetPortfolioEntriesByIdQueryHandler(IPortfolioRepository portfolioRepository, IMapper mapper)
        : IRequestHandler<GetPortfolioEntriesByIdQuery, Result<List<PortfolioEntryResponseDto>>>
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<List<PortfolioEntryResponseDto>>> Handle(GetPortfolioEntriesByIdQuery request, CancellationToken cancellationToken)
        {
            var portfolio = await _portfolioRepository.FindByIdAsync(request.PortfolioId);
            if (portfolio.IsFailure) return CommonErrors.NoEntitiesFound;
            if (portfolio.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<List<PortfolioEntryResponseDto>>(portfolio.Value.PortfolioEntries);
        }
    }
}
