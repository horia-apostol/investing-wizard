namespace InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeByCode
{
    public sealed record TradingHoursResponseDto
    {
        public TimeOnly? Open { get; set; }
        public TimeOnly? Close { get; set; }
        public TimeOnly? OpenUtc { get; set; }
        public TimeOnly? CloseUtc { get; set; }
        public List<string>? WorkingDays { get; set; }
    }
}
