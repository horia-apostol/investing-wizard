namespace InvestingWizard.Application.Features.Prices.Queries.GetPricesFromExternalApi
{
    public class PriceResponseDto
    {
        public DateOnly? Date { get; set; }
        public decimal? Open { get; set; }
        public decimal? High { get; set; }
        public decimal? Low { get; set; }
        public decimal? Close { get; set; }
        public long? Volume { get; set; }
        public decimal? AdjustedClose { get; set; }
        public string? SecurityCode { get; set; }
    }
}