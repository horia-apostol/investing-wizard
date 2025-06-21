using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class EarningsAnnualExternalDto
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }
        [JsonPropertyName("epsActual")]
        public decimal? EpsActual { get; set; }
    }
}