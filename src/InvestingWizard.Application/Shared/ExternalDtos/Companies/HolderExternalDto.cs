using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class HolderExternalDto
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("totalShares")]
        public decimal? TotalShares { get; set; }

        [JsonPropertyName("totalAssets")]
        public decimal? TotalAssets { get; set; }

        [JsonPropertyName("currentShares")]
        public long? CurrentShares { get; set; }

        [JsonPropertyName("change")]
        public long? Change { get; set; }

        [JsonPropertyName("change_p")]
        public decimal? ChangePercentage { get; set; }
    }
}