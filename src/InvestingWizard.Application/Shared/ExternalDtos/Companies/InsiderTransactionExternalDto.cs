using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class InsiderTransactionExternalDto
    {
        [JsonPropertyName("transactionDate")]
        public string? TransactionDate { get; set; }
        [JsonPropertyName("ownerName")]
        public string? OwnerName { get; set; }
        [JsonPropertyName("transactionCode")]
        public string? TransactionCode { get; set; }
        [JsonPropertyName("transactionAmount")]
        public long? TransactionAmount { get; set; }
        [JsonPropertyName("transactionPrice")]
        public decimal? TransactionPrice { get; set; }
        [JsonPropertyName("transactionAcquiredDisposed")]
        public string? TransactionAcquiredDisposed { get; set; }
        [JsonPropertyName("postTransactionAmount")]
        public string? PostTransactionAmount { get; set; }
        [JsonPropertyName("secLink")]
        public string? SecLink { get; set; }
    }
}