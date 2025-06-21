using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;

namespace InvestingWizard.Application.Features.Companies.Queries.GetAllCompaniesByExchangeCode
{
    internal sealed class GetAllCompaniesByExchangeCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetAllCompaniesByExchangeCodeQuery, Result<List<CompanyResponseDto>>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<List<CompanyResponseDto>>> Handle(GetAllCompaniesByExchangeCodeQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetAllByExchangeCodeAsync(request.ExchangeCode);

            return _mapper.Map<List<CompanyResponseDto>>(companies.Value);
        }

    }
}
