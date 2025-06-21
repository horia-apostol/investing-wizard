using AutoMapper;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Companies.Queries.GetNameByCode
{
    internal sealed class GetNameByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetNameByCodeQuery, Result<CompanyNameResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<CompanyNameResponseDto>> Handle(GetNameByCodeQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetCompanyNameByCodeAsync(request.Code);

            if (company.IsFailure) return company.Error;

            return _mapper.Map<CompanyNameResponseDto>(company.Value);
        }
    }
}
