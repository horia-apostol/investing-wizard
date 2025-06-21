namespace InvestingWizard.Application.Features.Companies.Queries.GetOutstandingSharesByCode
{
    public class OutstandingShareResponseDto
    {
        public string? Year { get; set; }
        public DateOnly? DateFormatted { get; set; }
        public string? SharesMln { get; set; }
        public decimal? Shares { get; set; }
    }
}