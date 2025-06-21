namespace InvestingWizard.Application.Features.Prices.Commands.AddPrice
{
    public sealed record AddPriceRequestDto
    {
        public DateOnly Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public decimal AdjustedClose { get; set; }
        public string SecurityCode { get; set; }
    }
}
