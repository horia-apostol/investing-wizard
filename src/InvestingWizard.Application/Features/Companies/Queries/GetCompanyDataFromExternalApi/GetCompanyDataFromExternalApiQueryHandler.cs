using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Application.Shared.ExternalDtos.Companies;
using InvestingWizard.Application.Shared.Interfaces;

namespace InvestingWizard.Application.Features.Companies.Queries.GetCompanyDataFromExternalApi
{
    internal sealed class GetCompanyDataFromExternalApiQueryHandler(IExternalApiService externalApiService, IMapper mapper)
        : IRequestHandler<GetCompanyDataFromExternalApiQuery, Result<CompanyExternalDto>>
    {
        private readonly IExternalApiService _externalApiService = externalApiService;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<CompanyExternalDto>> Handle(GetCompanyDataFromExternalApiQuery request, CancellationToken cancellationToken)
        {
            var company = await _externalApiService.GetCompanyDataAsync(request.Code);
            if (company.IsFailure) return company.Error;
            return _mapper.Map<CompanyExternalDto>(company.Value);
        }
    }
}
