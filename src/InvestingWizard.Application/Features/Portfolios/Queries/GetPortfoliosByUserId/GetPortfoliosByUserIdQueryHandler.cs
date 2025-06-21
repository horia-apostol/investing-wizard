using AutoMapper;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetPortfoliosByUserId
{
    internal sealed class GetPortfoliosByUserIdQueryHandler(IPortfolioRepository repository, IMapper mapper)
        : IRequestHandler<GetPortfoliosByUserIdQuery, Result<List<PortfolioIdResponseDto>>>
    {
        private readonly IPortfolioRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<List<PortfolioIdResponseDto>>> Handle(GetPortfoliosByUserIdQuery request, CancellationToken cancellationToken)
        {
            var portfolios = await _repository.GetPortfoliosByUserIdAsync(request.UserId);
            if (portfolios.IsFailure) return CommonErrors.NoEntitiesFound;
            return _mapper.Map<List<PortfolioIdResponseDto>>(portfolios.Value);
        }
    }
}
