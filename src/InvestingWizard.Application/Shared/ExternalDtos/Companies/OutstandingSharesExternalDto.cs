using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class OutstandingSharesExternalDto
    {
        [JsonPropertyName("annual")]
        public Dictionary<string, OutstandingShareExternalDto>? Annual { get; set; }
        [JsonPropertyName("quarterly")]
        public Dictionary<string, OutstandingShareExternalDto>? Quarterly { get; set; }
    }
}