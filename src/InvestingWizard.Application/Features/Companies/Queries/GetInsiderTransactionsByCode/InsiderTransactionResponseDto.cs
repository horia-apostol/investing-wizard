namespace InvestingWizard.Application.Features.Companies.Queries.GetInsiderTransactionsByCode
{
    public class InsiderTransactionResponseDto
    {
        public DateOnly? TransactionDate { get; set; }
        public string? OwnerName { get; set; }
        public string? TransactionCode { get; set; }
        public long? TransactionAmount { get; set; }
        public decimal? TransactionPrice { get; set; }
        public string? TransactionType { get; set; }
        public long? PostTransactionAmount { get; set; }
        public string? SecLink { get; set; }
    }
}