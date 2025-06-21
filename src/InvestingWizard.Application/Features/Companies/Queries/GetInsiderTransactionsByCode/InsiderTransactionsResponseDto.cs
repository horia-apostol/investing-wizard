using InvestingWizard.Domain.Companies;

namespace InvestingWizard.Application.Features.Companies.Queries.GetInsiderTransactionsByCode
{
    public class InsiderTransactionsResponseDto
    {
        public List<InsiderTransactionResponseDto>? Transactions { get; set; }
    }
}