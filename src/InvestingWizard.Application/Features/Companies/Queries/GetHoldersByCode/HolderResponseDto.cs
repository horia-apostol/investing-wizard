namespace InvestingWizard.Application.Features.Companies.Queries.GetHoldersByCode
{
    public class HolderResponseDto
    {
        public string? Name { get; set; }
        public DateOnly? Date { get; set; }
        public decimal? TotalShares { get; set; }
        public decimal? TotalAssets { get; set; }
        public long? CurrentShares { get; set; }
        public long? Change { get; set; }
        public decimal? ChangePercentage { get; set; }
    }
}