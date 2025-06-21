namespace InvestingWizard.Domain.Companies
{
    public class InsiderTransaction
    {
        public Guid Id { get; set; }
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
