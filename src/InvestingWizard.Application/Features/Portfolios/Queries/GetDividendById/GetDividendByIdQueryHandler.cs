using AutoMapper;
using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetDividendById
{
    internal sealed class GetDividendByIdQueryHandler(IDividendOrchestrationService dividendOrchestrationService, IMapper mapper)
        : IRequestHandler<GetDividendByIdQuery, Result<DividendResponseDto>>
    {
        private readonly IDividendOrchestrationService _dividendOrchestrationService = dividendOrchestrationService;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<DividendResponseDto>> Handle(GetDividendByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _dividendOrchestrationService.GetDividendByIdAsync(request.Id);
            if (result.IsFailure) return result.Error;
            return _mapper.Map<DividendResponseDto>(result.Value);
        }
    }
}
