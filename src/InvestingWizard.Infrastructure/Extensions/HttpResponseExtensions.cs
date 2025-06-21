using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using System.Text.Json;

namespace InvestingWizard.Infrastructure.Extensions
{
    public static class HttpResponseExtensions
    {
        public static async Task<Result<T>> HandleResponseAsync<T>(this HttpResponseMessage response) where T : class
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<T>(content);
                if (data == null) return CommonErrors.UnexpectedNullValue;
                return data;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var errorMessage = $"Error: {response.StatusCode}, Content: {errorContent}";
                return new CustomError(response.StatusCode.ToString(), errorMessage);
            }
        }
    }
}
