namespace InvestingWizard.Application.Features.Companies.Queries.GetAllCompanyCodes
{
    public sealed record CodesResponseDto
    {
        public List<string?>? Codes { get; init; }
    }
}