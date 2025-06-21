namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class ValuationExternalDto
    {
        public decimal? TrailingPE { get; set; }
        public decimal? ForwardPE { get; set; }
        public decimal? PriceSalesTTM { get; set; }
        public decimal? PriceBookMRQ { get; set; }
        public long? EnterpriseValue { get; set; }
        public decimal? EnterpriseValueRevenue { get; set; }
        public decimal? EnterpriseValueEbitda { get; set; }
    }
}