using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetTechnicalsByCode
{
    internal sealed class GetTechnicalsByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetTechnicalsByCodeQuery, Result<TechnicalsResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<TechnicalsResponseDto>> Handle(GetTechnicalsByCodeQuery request, CancellationToken cancellationToken)
        {
            var technicals = await _companyRepository.GetTechnicalsByCodeAsync(request.Code);

            if (technicals.IsFailure) return technicals.Error;
            if (technicals.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<TechnicalsResponseDto>(technicals.Value.Technicals);
        }
    }
}
