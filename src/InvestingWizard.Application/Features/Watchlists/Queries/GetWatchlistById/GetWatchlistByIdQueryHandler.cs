using AutoMapper;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Watchlists.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Queries.GetWatchlistById
{
    internal sealed class GetWatchlistByIdQueryHandler(IWatchlistRepository watchlistRepository, IMapper mapper)
        : IRequestHandler<GetWatchlistByIdQuery, Result<WatchlistResponseDto>>
    {
        private readonly IWatchlistRepository _watchlistRepository = watchlistRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<WatchlistResponseDto>> Handle(GetWatchlistByIdQuery request, CancellationToken cancellationToken)
        {
            var watchlist = await _watchlistRepository.FindByIdAsync(request.Id);
            if (watchlist.IsFailure) return watchlist.Error;
            return _mapper.Map<WatchlistResponseDto>(watchlist.Value);
        }
    }
}
