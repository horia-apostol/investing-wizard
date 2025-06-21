using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetHoldersByCode
{
    internal sealed class GetHoldersByCodeQueryHandler(ICompanyRepository repository, IMapper mapper)
        : IRequestHandler<GetHoldersByCodeQuery, Result<HoldersResponseDto>>
    {
        private readonly ICompanyRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<HoldersResponseDto>> Handle(GetHoldersByCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetHoldersByCodeAsync(request.Code);
            if (result.IsFailure) return result.Error;
            if (result.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<HoldersResponseDto>(result.Value.Holders);
        }
    }
}
