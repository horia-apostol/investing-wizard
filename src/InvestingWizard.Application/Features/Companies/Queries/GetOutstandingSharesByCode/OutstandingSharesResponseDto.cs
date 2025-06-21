using InvestingWizard.Domain.Companies;

namespace InvestingWizard.Application.Features.Companies.Queries.GetOutstandingSharesByCode
{
    public class OutstandingSharesResponseDto
    {
        public List<OutstandingShareResponseDto>? AnnualShares { get; set; }
        public List<OutstandingShareResponseDto>? QuarterlyShares { get; set; }
    }
}