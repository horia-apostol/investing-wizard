using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class OutstandingShareExternalDto
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }
        [JsonPropertyName("dateFormatted")]
        public string? DateFormatted { get; set; }
        [JsonPropertyName("sharesMln")]
        public string? SharesMln { get; set; }
        [JsonPropertyName("shares")]
        public decimal? Shares { get; set; }
    }
}