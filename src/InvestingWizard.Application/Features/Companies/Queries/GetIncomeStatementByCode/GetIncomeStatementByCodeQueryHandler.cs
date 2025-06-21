using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetIncomeStatementByCode
{
    internal sealed class GetIncomeStatementByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetIncomeStatementByCodeQuery, Result<IncomeStatementReportResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<IncomeStatementReportResponseDto>> Handle(GetIncomeStatementByCodeQuery request, CancellationToken cancellationToken)
        {
            var incomeStatement = await _companyRepository.GetIncomeStatementByCodeAsync(request.Code);

            if (incomeStatement.IsFailure) return incomeStatement.Error;
            if (incomeStatement.Value is null) return CommonErrors.UnexpectedNullValue;
            if (incomeStatement.Value.Financials is null) return CommonErrors.UnexpectedNullValue;
            if (incomeStatement.Value.Financials.IncomeStatement is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<IncomeStatementReportResponseDto>(incomeStatement.Value.Financials.IncomeStatement);
        }
    }
}
