namespace InvestingWizard.Domain.Exchanges
{
    public class Holiday
    {
        public Guid Id { get; set; }
        public string? ExchangeCode { get; set; }
        public string? Name { get; set; }
        public DateOnly? Date { get; set; }
        public string? Type { get; set; }
    }
}