namespace InvestingWizard.Domain.Exchanges
{
    public sealed class TradingHours
    {
        public TimeOnly? Open { get; set; }
        public TimeOnly? Close { get; set; }
        public TimeOnly? OpenUtc { get; set; }
        public TimeOnly? CloseUtc { get; set; }
        public List<string>? WorkingDays { get; set; }
    }
}