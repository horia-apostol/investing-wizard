using AutoMapper;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Exchanges.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Exchanges.Queries.GetAllExchanges
{
    internal class GetAllExchangesQueryHandler(IExchangeRepository exchangeRepository, IMapper mapper)
        : IRequestHandler<GetAllExchangesQuery, Result<IReadOnlyList<ExchangeNameCodeResponseDto>>>
    {
        private readonly IExchangeRepository _exchangeRepository = exchangeRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<IReadOnlyList<ExchangeNameCodeResponseDto>>> Handle(GetAllExchangesQuery request, CancellationToken cancellationToken)
        {
            var exchanges = await _exchangeRepository.GetAllAsync();

            return _mapper.Map<List<ExchangeNameCodeResponseDto>>(exchanges.Value);
        }
    }
}
