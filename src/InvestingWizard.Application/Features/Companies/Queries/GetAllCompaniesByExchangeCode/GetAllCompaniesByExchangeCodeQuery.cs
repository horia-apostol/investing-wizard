using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetAllCompaniesByExchangeCode
{
    public record GetAllCompaniesByExchangeCodeQuery(
        string ExchangeCode) : IRequest<Result<List<CompanyResponseDto>>>;
}
