using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetEarningsByCode
{
    internal sealed class GetEarningsByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetEarningsByCodeQuery, Result<EarningsResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<EarningsResponseDto>> Handle(GetEarningsByCodeQuery request, CancellationToken cancellationToken)
        {
            var earnings = await _companyRepository.GetEarningsByCodeAsync(request.Code);

            if (earnings.IsFailure) return earnings.Error;
            if (earnings.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<EarningsResponseDto>(earnings.Value.Earnings);
        }
    }
}
