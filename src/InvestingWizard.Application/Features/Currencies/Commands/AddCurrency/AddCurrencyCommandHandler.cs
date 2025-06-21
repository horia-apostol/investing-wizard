using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Currencies;
using InvestingWizard.Domain.Currencies.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Currencies.Commands.AddCurrency
{
    internal sealed class AddCurrencyCommandHandler(ICurrencyRepository currencyRepository)
        : IRequestHandler<AddCurrencyCommand, Result>
    {
        private readonly ICurrencyRepository _currencyRepository = currencyRepository;
        public async Task<Result> Handle(AddCurrencyCommand request, CancellationToken cancellationToken)
        {
            var result = await _currencyRepository.AddAsync(Currency.Create(request.Code, request.Name, request.Symbol));
            if (result.IsFailure) return CommonErrors.UnexpectedError;
            return result;
        }
    }
}
