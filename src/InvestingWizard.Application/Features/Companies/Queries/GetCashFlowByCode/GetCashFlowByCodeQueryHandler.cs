using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetCashFlowByCodeQuery
{
    internal sealed class GetCashFlowByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetCashFlowByCodeQuery, Result<CashFlowReportResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<CashFlowReportResponseDto>> Handle(GetCashFlowByCodeQuery request, CancellationToken cancellationToken)
        {
            var cashFlow = await _companyRepository.GetCashFlowByCodeAsync(request.Code);

            if (cashFlow.IsFailure) return cashFlow.Error;
            if (cashFlow.Value is null) return CommonErrors.UnexpectedNullValue;
            if (cashFlow.Value.Financials is null) return CommonErrors.UnexpectedNullValue;
            if (cashFlow.Value.Financials.CashFlow is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<CashFlowReportResponseDto>(cashFlow.Value.Financials.CashFlow);
        }
    }
}
