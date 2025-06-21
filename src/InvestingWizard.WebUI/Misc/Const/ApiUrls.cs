namespace InvestingWizard.WebUI.Misc.Const
{
    public static class ApiUrls
    {
        public const string BaseUrl = "https://localhost:7186/api";

        public const string CompaniesUrl = BaseUrl + "/companies/external";

        public const string ExchangesUrl = BaseUrl + "/exchanges/external";
        public const string ExchangesGeneralUrl = BaseUrl + "/exchanges";
        public const string ExchangeStatusUrl = BaseUrl + "/exchanges/status";
        public const string PricesUrl = BaseUrl + "/prices/external";
        public const string LivePricesUrl = BaseUrl + "/live-prices-cache/{0}";
        public const string PortfoliosUrl = BaseUrl + "/portfolios";
        public const string GetPortfoliosByUserId = BaseUrl + "/portfolios/all/{0}";
        public const string TotalDividendUrl = BaseUrl + "/portfolios/total-dividend/{0}";
        public const string PortfolioEntriesUrl = BaseUrl + "/portfolios/{0}/entries?userId={1}";
        public const string ProfitLossUrl = BaseUrl + "/portfolios/{0}/profit-loss/{1}";
        public const string DividendUrl = BaseUrl + "/portfolios/{0}/dividend?userId={1}";
        public const string AddPortfolio = BaseUrl + "/portfolios";
        public const string UpdatePortfolioName = BaseUrl + "/portfolios/{0}/name";
        public const string DeletePortfolio = BaseUrl + "/portfolios/{0}";
        public const string GetTransactionsByPortfolioId = BaseUrl + "/portfolios/{0}/transactions";
        public const string AllCompanyCodesUrl = BaseUrl + "/companies/all-codes";
        public const string AddTransactionUrl = BaseUrl + "/portfolios/open-transaction";
        public const string CloseTransactionUrl = BaseUrl + "/portfolios/close-transaction";
        public const string CloseTransactionPartiallyUrl = BaseUrl + "/portfolios/close-transaction-partially";
        public const string ApproveSuggestionUrl = BaseUrl + "/portfolios/approve-suggestion";
        public const string GetSuggestionsUrl = BaseUrl + "/optimization/get-suggestions";
        public static string GetWatchlistById(string watchlistId) => $"{BaseUrl}/watchlists/{watchlistId}";
        public static string GetWatchlistsByUserId(string userId) => $"{BaseUrl}/watchlists/user/{userId}";
        public static string AddWatchlist => $"{BaseUrl}/watchlists";
        public static string UpdateWatchlistName(string watchlistId) => $"{BaseUrl}/watchlists/{watchlistId}";
        public static string DeleteWatchlist(string watchlistId) => $"{BaseUrl}/watchlists/{watchlistId}";
        public static string AddSecurityToWatchlist(string watchlistId, string companyCode) => $"{BaseUrl}/watchlists/{watchlistId}/add-security/{companyCode}";
        public static string RemoveSecurityFromWatchlist(string watchlistId, string companyCode) => $"{BaseUrl}/watchlists/{watchlistId}/remove-security/{companyCode}";
        public static string GetAllCompanyCodes => $"{BaseUrl}/companies/all-codes";
        public static string GetLivePriceByCode(string companyCode) => $"{BaseUrl}/live-prices-cache/{companyCode}";
    }
}
