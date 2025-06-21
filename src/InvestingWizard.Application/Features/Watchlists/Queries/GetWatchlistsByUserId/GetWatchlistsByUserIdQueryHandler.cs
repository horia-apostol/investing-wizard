using AutoMapper;
using InvestingWizard.Application.Features.Watchlists.Queries.GetWatchlistById;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Watchlists.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Queries.GetWatchlistsByUserId
{
    internal sealed class GetWatchlistsByUserIdQueryHandler(IWatchlistRepository watchlistRepository, IMapper mapper)
        : IRequestHandler<GetWatchlistsByUserIdQuery, Result<List<WatchlistResponseDto>>>
    {
        private readonly IWatchlistRepository _watchlistRepository = watchlistRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<List<WatchlistResponseDto>>> Handle(GetWatchlistsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _watchlistRepository.GetByUserIdAsync(request.UserId);
            return _mapper.Map<List<WatchlistResponseDto>>(result.Value);
        }
    }
}
