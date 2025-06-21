using InvestingWizard.Application.Shared.ExternalDtos.Companies;
using InvestingWizard.Application.Shared.ExternalDtos.Exchanges;
using InvestingWizard.Application.Shared.ExternalDtos.Prices;
using InvestingWizard.Domain.Companies;
using InvestingWizard.Domain.Exchanges;
using InvestingWizard.Domain.Prices;

namespace InvestingWizard.Application.Shared.Interfaces
{
    public interface IEntityMapper
    {
        Company Map(string companyCode, string exchangeCode, CompanyExternalDto companyData);
        Exchange Map(string exchangeCode, ExchangeExternalDto exchangeData);
        Price Map(string securityCode, PriceExternalDto priceData);
    }
}
