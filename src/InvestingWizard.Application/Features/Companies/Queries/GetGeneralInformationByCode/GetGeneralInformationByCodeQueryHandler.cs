using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetGeneralInformationByCode
{
    internal sealed class GetGeneralInformationByCodeQueryHandler(ICompanyRepository repository, IMapper mapper) 
        : IRequestHandler<GetGeneralInformationByCodeQuery, Result<GeneralInformationResponseDto>>
    {
        private readonly ICompanyRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<GeneralInformationResponseDto>> Handle(GetGeneralInformationByCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetGeneralInformationByCodeAsync(request.Code);

            if (result.IsFailure) return result.Error;
            if (result.Value is null) return CommonErrors.UnexpectedNullValue;
            if (result.Value.GeneralInformation is null) return CommonErrors.UnexpectedNullValue;

            return _mapper.Map<GeneralInformationResponseDto>(result.Value.GeneralInformation);
        }
    }
}
