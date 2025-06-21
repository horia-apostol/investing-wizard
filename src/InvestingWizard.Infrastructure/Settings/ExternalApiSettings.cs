namespace InvestingWizard.Infrastructure.Settings
{
    public sealed class ExternalApiSettings
    {
        public string? BaseUrl { get; set; }
        public string? ApiToken { get; set; }
        public ExternalApiSettings() { }
    }
}
