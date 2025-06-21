using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Exchanges.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Exchanges.Commands.UpdateExchangeFromExternalApi
{
    internal sealed class UpdateExchangeFromExternalApiCommandHandler(IExchangeRepository exchangeRepository, IExternalApiService externalApiService, IEntityMapper entityMapper)
        : IRequestHandler<UpdateExchangeFromExternalApiCommand, Result>
    {
        private readonly IExternalApiService _externalApiService = externalApiService;
        private readonly IEntityMapper _entityMapper = entityMapper;
        private readonly IExchangeRepository _exchangeRepository = exchangeRepository;

        public async Task<Result> Handle(UpdateExchangeFromExternalApiCommand request, CancellationToken cancellationToken)
        {


            return Result.Success();

        }
    }
}
