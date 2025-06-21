using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Prices.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Prices.Commands.AddPrice
{
    internal sealed class AddPriceCommandHandler(IPriceRepository priceRepository)
        : IRequestHandler<AddPriceCommand, Result>
    {
        private readonly IPriceRepository _priceRepository = priceRepository;
        public async Task<Result> Handle(AddPriceCommand request, CancellationToken cancellationToken)
        {
            var result = await _priceRepository.AddAsync(request.Price);
            if (result.IsFailure) return CommonErrors.UnexpectedError;
            return result;
        }
    }
}
