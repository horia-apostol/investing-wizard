using InvestingWizard.Domain.Companies;

namespace InvestingWizard.Application.Features.Companies.Queries.GetHoldersByCode
{
    public class HoldersResponseDto
    {
        public List<HolderResponseDto>? Institutions { get; set; }
        public List<HolderResponseDto>? Funds { get; set; }
    }
}