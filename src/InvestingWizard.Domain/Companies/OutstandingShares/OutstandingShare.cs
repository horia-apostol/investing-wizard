namespace InvestingWizard.Domain.Companies
{
    public class OutstandingShare
    {
        public Guid Id { get; set; }
        public string? Year { get; set; }
        public DateOnly? DateFormatted { get; set; }
        public string? SharesMln { get; set; }
        public decimal? Shares { get; set; }
    }
}
