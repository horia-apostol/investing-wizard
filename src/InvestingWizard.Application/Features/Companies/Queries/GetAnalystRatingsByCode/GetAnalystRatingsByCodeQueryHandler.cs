using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetAnalystRatingsByCode
{
    internal sealed class GetAnalystRatingsByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetAnalystRatingsByCodeQuery, Result<AnalystRatingsResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<AnalystRatingsResponseDto>> Handle(GetAnalystRatingsByCodeQuery request, CancellationToken cancellationToken)
        {
            var analystRatings = await _companyRepository.GetAnalystRatingsByCodeAsync(request.Code);

            if (analystRatings.IsFailure) return analystRatings.Error;
            if (analystRatings.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<AnalystRatingsResponseDto>(analystRatings.Value.AnalystRatings);
        }
    }
}
