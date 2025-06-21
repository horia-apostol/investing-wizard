using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetAllCompanyCodes
{
    internal sealed class GetAllCompanyCodesQueryHandler(ICompanyRepository companyRepository)
        : IRequestHandler<GetAllCompanyCodesQuery, Result<CodesResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        public async Task<Result<CodesResponseDto>> Handle(GetAllCompanyCodesQuery request, CancellationToken cancellationToken)
        {
            var result = await _companyRepository.GetAllCodesAsync();
            var codes = new CodesResponseDto { Codes = result.Value };
            if (codes == null) return CommonErrors.UnexpectedNullValue;
            return codes;
        }
    }
}
