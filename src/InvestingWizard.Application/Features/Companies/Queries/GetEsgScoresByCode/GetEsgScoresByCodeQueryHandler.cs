using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetEsgScoresByCode
{
    internal sealed class GetEsgScoresByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetEsgScoresByCodeQuery, Result<EsgScoresResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<EsgScoresResponseDto>> Handle(GetEsgScoresByCodeQuery request, CancellationToken cancellationToken)
        {
            var EsgScores = await _companyRepository.GetEsgScoresByCodeAsync(request.Code);

            if (EsgScores.IsFailure) return EsgScores.Error;
            if (EsgScores.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<EsgScoresResponseDto>(EsgScores.Value.EsgScores);
        }
    }
}
