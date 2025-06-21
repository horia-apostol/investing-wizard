using AutoMapper;
using InvestingWizard.Domain.Interfaces.Repositories;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetTransactionsById
{
    internal sealed class GetPortfolioTransactionsByIdQueryHandler(IPortfolioRepository portfolioRepository, IMapper mapper)
        : IRequestHandler<GetPortfolioTransactionsByIdQuery, Result<List<TransactionResponseDto>>>
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<List<TransactionResponseDto>>> Handle(GetPortfolioTransactionsByIdQuery request, CancellationToken cancellationToken)
        {
            var portfolio = await _portfolioRepository.FindByIdAsync(request.PortfolioId);
            if (portfolio.IsFailure) return CommonErrors.NoEntitiesFound;
            if (portfolio.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<List<TransactionResponseDto>>(portfolio.Value.Transactions);
        }
    }
}
