using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using InvestingWizard.TradingAssistant.Settings;
using Microsoft.Extensions.Options;

namespace InvestingWizard.TradingAssistant.Clients.OpenAI
{
    public class OpenAIClient
    {
        private readonly HttpClient _httpClient;
        private readonly OpenAISettings _settings;

        public OpenAIClient(HttpClient httpClient, IOptions<OpenAISettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.ApiKey);
        }

        public async Task<string> GetResponseAsync(string prompt)
        {
            var requestBody = new
            {
                model = "gpt-3.5-turbo-16k",
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = prompt }
                },
            };

            var response = await _httpClient.PostAsJsonAsync("/v1/chat/completions", requestBody);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request to OpenAI failed: {response.StatusCode}, {error}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var jsonDocument = JsonDocument.Parse(content);
            var responseText = jsonDocument.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
            return responseText;
        }
    }
}
