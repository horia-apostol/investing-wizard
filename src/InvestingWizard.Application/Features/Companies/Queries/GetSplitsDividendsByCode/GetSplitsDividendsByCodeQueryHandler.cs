using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetSplitsDividendsByCode
{
    internal sealed class GetSplitsDividendsByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetSplitsDividendsByCodeQuery, Result<SplitsDividendsResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<SplitsDividendsResponseDto>> Handle(GetSplitsDividendsByCodeQuery request, CancellationToken cancellationToken)
        {
            var SplitsDividends = await _companyRepository.GetSplitsDividendsByCodeAsync(request.Code);

            if (SplitsDividends.IsFailure) return SplitsDividends.Error;
            if (SplitsDividends.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<SplitsDividendsResponseDto>(SplitsDividends.Value.SplitsDividends);
        }
    }
}
