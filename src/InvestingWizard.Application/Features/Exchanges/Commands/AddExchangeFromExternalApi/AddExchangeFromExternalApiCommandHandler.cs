using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Exchanges.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Exchanges.Commands.AddExchangeFromExternalApi
{
    internal sealed class AddExchangeFromExternalApiCommandHandler(
        IExchangeRepository exchangeRepository, 
        IExternalApiService externalApiService, 
        IEntityMapper entityMapper)
        : IRequestHandler<AddExchangeFromExternalApiCommand, Result>
    {
        private readonly IExchangeRepository _exchangeRepository = exchangeRepository;
        private readonly IExternalApiService _externalApiService = externalApiService;
        private readonly IEntityMapper _entityMapper = entityMapper;
        public async Task<Result> Handle(AddExchangeFromExternalApiCommand request, CancellationToken cancellationToken)
        {
            var exchangeData = await _externalApiService.GetExchangeDataAsync(request.Code);

            if (exchangeData.IsFailure) return CommonErrors.NoEntitiesFound;
            if (exchangeData.Value is null) return CommonErrors.UnexpectedNullValue;

            var newExchange = _entityMapper.Map(request.Code, exchangeData.Value);

            await _exchangeRepository.AddAsync(newExchange);
            return Result.Success();
        }
    }
}
