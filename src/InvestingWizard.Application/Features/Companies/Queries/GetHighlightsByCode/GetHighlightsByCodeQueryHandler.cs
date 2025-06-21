using AutoMapper;
using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;

namespace InvestingWizard.Application.Features.Companies.Queries.GetHighlightsByCode
{
    internal sealed class GetHighlightsByCodeQueryHandler(ICompanyRepository repository, IMapper mapper) 
        : IRequestHandler<GetHighlightsByCodeQuery, Result<HighlightsResponseDto>>
    {
        private readonly ICompanyRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<HighlightsResponseDto>> Handle(GetHighlightsByCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetHighlightsByCodeAsync(request.Code);

            if (result.IsFailure) return result.Error;
            if (result.Value is null) return CommonErrors.UnexpectedNullValue;
            return _mapper.Map<HighlightsResponseDto>(result.Value.Highlights);
        }
    }
}
