namespace InvestingWizard.Domain.Companies
{
    public class Holder
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateOnly? Date { get; set; }
        public decimal? TotalShares { get; set; }
        public decimal? TotalAssets { get; set; }
        public long? CurrentShares { get; set; }
        public long? Change { get; set; }
        public decimal? ChangePercentage { get; set; }
    }
}
