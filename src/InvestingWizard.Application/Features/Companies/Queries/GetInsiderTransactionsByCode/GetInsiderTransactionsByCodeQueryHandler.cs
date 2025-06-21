using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetInsiderTransactionsByCode
{
    internal sealed class GetInsiderTransactionsByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetInsiderTransactionsByCodeQuery, Result<InsiderTransactionsResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<InsiderTransactionsResponseDto>> Handle(GetInsiderTransactionsByCodeQuery request, CancellationToken cancellationToken)
        {
            var InsiderTransactions = await _companyRepository.GetInsiderTransactionsByCodeAsync(request.Code);

            if (InsiderTransactions.IsFailure) return InsiderTransactions.Error;
            if (InsiderTransactions.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<InsiderTransactionsResponseDto>(InsiderTransactions.Value.InsiderTransactions);
        }
    }
}
