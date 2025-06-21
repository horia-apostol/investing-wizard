using static InvestingWizard.WebUI.Components.Pages.AdminDashboard;

namespace InvestingWizard.WebUI.Interfaces
{
    public interface IAdminDataService
    {
        Task<ApiResponse> AddCompany(string companyCode);
        Task<ApiResponse> UpdateCompany(string companyCode);
        Task<ApiResponse> AddExchange(string exchangeCode);
        Task<ApiResponse> UpdateExchange(string exchangeCode);
        Task<ApiResponse> AddPrices(string pricesCode);
    }
}
