using AutoMapper;
using InvestingWizard.Domain.Companies;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using MediatR;

namespace InvestingWizard.Application.Features.Companies.Queries.GetDividendRateByCode
{
    internal sealed class GetDividendRateByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetDividendRateByCodeQuery, Result<DividendRateResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<DividendRateResponseDto>> Handle(GetDividendRateByCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _companyRepository.GetSplitsDividendsByCodeAsync(request.Code);
            if (result.IsFailure) return result.Error;
            if (result.Value is null) return CommonErrors.EntityNotFound;
            if (result.Value.SplitsDividends is null) return CommonErrors.UnexpectedNullValue;
            if (result.Value.SplitsDividends.ForwardAnnualDividendRate is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<DividendRateResponseDto>(new DividendRateResult(result.Value.SplitsDividends.ForwardAnnualDividendRate, ""));
        }
    }
}
