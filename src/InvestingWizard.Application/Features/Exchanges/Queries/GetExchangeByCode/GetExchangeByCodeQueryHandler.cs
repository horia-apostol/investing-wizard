using AutoMapper;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Exchanges.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeByCode
{
    internal sealed class GetExchangeByCodeQueryHandler(IExchangeRepository exchangeRepository, IMapper mapper)
        : IRequestHandler<GetExchangeByCodeQuery, Result<ExchangeResponseDto>>
    {
        private readonly IExchangeRepository _exchangeRepository = exchangeRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<ExchangeResponseDto>> Handle(GetExchangeByCodeQuery request, CancellationToken cancellationToken)
        {
            var exchange = await _exchangeRepository.GetExchangeByCode(request.Code);

            if (exchange.IsFailure) return CommonErrors.EntityNotFound;

            return _mapper.Map<ExchangeResponseDto>(exchange.Value);
        }
    }

}
