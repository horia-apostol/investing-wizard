namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class AnalystRatingsExternalDto
    {
        public decimal? Rating { get; set; }
        public decimal? TargetPrice { get; set; }
        public int? StrongBuy { get; set; }
        public int? Buy { get; set; }
        public int? Hold { get; set; }
        public int? Sell { get; set; }
        public int? StrongSell { get; set; }
    }
}