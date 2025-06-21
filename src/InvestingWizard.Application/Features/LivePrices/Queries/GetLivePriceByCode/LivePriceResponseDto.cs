namespace InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode
{
    public sealed record LivePriceResponseDto
    {
        public string? Code { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal Change { get; set; }
        public decimal ChangePercent { get; set; }
    }
}