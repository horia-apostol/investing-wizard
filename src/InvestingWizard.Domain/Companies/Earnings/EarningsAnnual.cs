namespace InvestingWizard.Domain.Companies
{
    public class EarningsAnnual
    {
        public Guid Id { get; set; }
        public DateOnly? Date { get; set; }
        public decimal? EpsActual { get; set; }
    }
}
