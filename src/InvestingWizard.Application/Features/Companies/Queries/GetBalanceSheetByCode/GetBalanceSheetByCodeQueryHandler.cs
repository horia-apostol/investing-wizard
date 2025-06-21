using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetBalanceSheetByCodeQuery
{
    internal sealed class GetBalanceSheetByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetBalanceSheetByCodeQuery, Result<BalanceSheetReportResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<BalanceSheetReportResponseDto>> Handle(GetBalanceSheetByCodeQuery request, CancellationToken cancellationToken)
        {
            var balanceSheet = await _companyRepository.GetBalanceSheetByCodeAsync(request.Code);

            if (balanceSheet.IsFailure) return balanceSheet.Error;
            if (balanceSheet.Value == null) return CommonErrors.UnexpectedNullValue;
            if (balanceSheet.Value.Financials == null) return CommonErrors.UnexpectedNullValue;
            if (balanceSheet.Value.Financials.BalanceSheet == null) return CommonErrors.UnexpectedNullValue;

            return _mapper.Map<BalanceSheetReportResponseDto>(balanceSheet.Value.Financials.BalanceSheet);
        }
    }
}
