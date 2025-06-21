namespace InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeStatusByCode
{
    public sealed record ExchangeStatusDto
    {
        public bool IsOpen { get; init; }
        public bool WasOpenToday { get; init; }
        public TimeSpan TimeUntilNextOpen { get; init; }
    }
}