using MediatR;
using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Companies.Repositories;
using InvestingWizard.Application.Shared.Interfaces;

namespace InvestingWizard.Application.Features.Companies.Commands.UpdateCompanyFromExternalApi
{
    internal sealed class UpdateCompanyFromExternalApiCommandHandler(ICompanyRepository companyRepository, IExternalApiService externalApiService, IEntityMapper entityMapper)
        : IRequestHandler<UpdateCompanyFromExternalApiCommand, Result>
    {
        private readonly IExternalApiService _externalApiService = externalApiService;
        private readonly IEntityMapper _entityMapper = entityMapper;
        private readonly ICompanyRepository _companyRepository = companyRepository;

        public async Task<Result> Handle(UpdateCompanyFromExternalApiCommand request, CancellationToken cancellationToken)
        {
            /*
            var existingCompany = await _companyRepository.GetCompanyCodeAndExchangeCodeByCode(request.Code);
            if (existingCompany == null) return CommonErrors.NoEntitiesFound;

            var companyData = await _externalApiService.GetCompanyDataAsync(request.Code);
            if (companyData.IsFailure) return CommonErrors.NoEntitiesFound;
            if (companyData.Value == null) return CommonErrors.UnexpectedNullValue;

            if (existingCompany.Value == null) return CommonErrors.UnexpectedNullValue;

            var updatedCompany = _entityMapper.Map(companyData.Value);
            updatedCompany.Code = existingCompany.Value.Code;
            updatedCompany.ExchangeCode = existingCompany.Value.ExchangeCode;

            await _companyRepository.UpdateAsync(updatedCompany);*/
            return Result.Success();

        }
    }
}
