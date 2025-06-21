namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class EarningsExternalDto
    {
        public Dictionary<string, EarningsHistoryExternalDto>? History { get; set; }
        public Dictionary<string, EarningsTrendExternalDto>? Trend { get; set; }
        public Dictionary<string, EarningsAnnualExternalDto>? Annual { get; set; }

    }
}