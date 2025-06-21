using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetSharesStatsByCode
{
    internal sealed class GetSharesStatsByCodeQueryHandler (ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetSharesStatsByCodeQuery, Result<SharesStatsResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<SharesStatsResponseDto>> Handle(GetSharesStatsByCodeQuery request, CancellationToken cancellationToken)
        {
            var sharesStats = await _companyRepository.GetSharesStatsByCodeAsync(request.Code);

            if (sharesStats.IsFailure) return sharesStats.Error;
            if (sharesStats.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<SharesStatsResponseDto>(sharesStats.Value.SharesStats);
        }
    }
}
