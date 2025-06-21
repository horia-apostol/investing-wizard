using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetValuationByCode
{
    internal sealed class GetValuationByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper) 
        : IRequestHandler<GetValuationByCodeQuery, Result<ValuationResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<ValuationResponseDto>> Handle(GetValuationByCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _companyRepository.GetValuationByCodeAsync(request.Code);

            if (result.IsFailure) return result.Error;
            if (result.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<ValuationResponseDto>(result.Value.Valuation);
        }
    }
}
