namespace InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeByCode
{
    public sealed record HolidayResponseDto
    {
        public string? Name { get; set; }
        public DateOnly? Date { get; set; }
        public string? Type { get; set; }
    }
}