using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetOutstandingSharesByCode
{
    internal sealed class GetOutstandingSharesByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        : IRequestHandler<GetOutstandingSharesByCodeQuery, Result<OutstandingSharesResponseDto>>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<OutstandingSharesResponseDto>> Handle(GetOutstandingSharesByCodeQuery request, CancellationToken cancellationToken)
        {
            var outstandingShares = await _companyRepository.GetOutstandingSharesByCodeAsync(request.Code);

            if (outstandingShares.IsFailure) return outstandingShares.Error;
            if (outstandingShares.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<OutstandingSharesResponseDto>(outstandingShares.Value.OutstandingShares);
        }
    }
}
