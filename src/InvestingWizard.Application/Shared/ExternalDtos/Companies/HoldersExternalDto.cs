namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class HoldersExternalDto
    {
        public Dictionary<string, HolderExternalDto>? Institutions { get; set; }
        public Dictionary<string, HolderExternalDto>? Funds { get; set; }
    }
}