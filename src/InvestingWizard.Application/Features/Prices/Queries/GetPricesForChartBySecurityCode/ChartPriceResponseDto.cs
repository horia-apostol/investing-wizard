namespace InvestingWizard.Application.Features.Prices.Queries.GetPricesForChartBySecurityCode
{
    public class ChartPriceResponseDto
    {
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double High { get; set; }
        public Double Volume { get; set; }
    }
}