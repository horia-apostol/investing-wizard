namespace InvestingWizard.Infrastructure.Helpers
{
    public static class UrlHelper
    {
        public static string BuildUrl(string baseUrl, string endpoint, Dictionary<string, string> parameters)
        {
            var url = $"{baseUrl}/{endpoint}?{string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}"))}";
            return url;
        }
    }
}