namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class EsgScoresExternalDto
    {
        public string? Disclaimer { get; set; }
        public string? RatingDate { get; set; }
        public decimal? TotalEsg { get; set; }
        public decimal? TotalEsgPercentile { get; set; }
        public decimal? EnvironmentScore { get; set; }
        public decimal? EnvironmentScorePercentile { get; set; }
        public decimal? SocialScore { get; set; }
        public decimal? SocialScorePercentile { get; set; }
        public decimal? GovernanceScore { get; set; }
        public decimal? GovernanceScorePercentile { get; set; }
        public int? ControversyLevel { get; set; }
        public Dictionary<string, ActivityInvolvementExternalDto>? ActivitiesInvolvement { get; set; }
    }
}