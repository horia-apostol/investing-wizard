namespace InvestingWizard.Application.Features.Watchlists.Queries.GetWatchlistById
{
    public class WatchlistResponseDto
    {
        public Guid Id { get; init; }
        public string? Name { get; set; }
        public List<string>? SecurityCodes { get; set; }
    }
}