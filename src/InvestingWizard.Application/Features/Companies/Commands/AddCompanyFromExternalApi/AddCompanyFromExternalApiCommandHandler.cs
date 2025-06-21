using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Application.Shared.Interfaces;

namespace InvestingWizard.Application.Features.Companies.Commands.AddCompanyFromExternalApi
{
    internal sealed class AddCompanyFromExternalApiCommandHandler(
        ICompanyRepository companyRepository, 
        IExternalApiService externalApiService, 
        IEntityMapper entityMapper): IRequestHandler<AddCompanyFromExternalApiCommand, Result>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;
        private readonly IExternalApiService _externalApiService = externalApiService;
        private readonly IEntityMapper _entityMapper = entityMapper;
        public async Task<Result> Handle(AddCompanyFromExternalApiCommand request, CancellationToken cancellationToken)
        {
            var companyData = await _externalApiService.GetCompanyDataAsync(request.Code);

            if (companyData.IsFailure) return CommonErrors.NoEntitiesFound;
            if (companyData.Value == null) return CommonErrors.UnexpectedNullValue;

            await _companyRepository.AddAsync(_entityMapper.Map(request.Code, ExtractExchangeCode(request.Code), companyData.Value));
            return Result.Success();
        }
        private static string ExtractExchangeCode(string code)
        {
            return code.Split('.')[1];
        }
    }
}
