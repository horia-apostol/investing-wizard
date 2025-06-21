using AutoMapper;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Interfaces.Repositories;
using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioById
{
    internal sealed class GetPortfolioByIdQueryHandler(IPortfolioRepository portfolioRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        : IRequestHandler<GetPortfolioByIdQuery, Result<PortfolioResponseDto>>
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<Result<PortfolioResponseDto>> Handle(GetPortfolioByIdQuery request, CancellationToken cancellationToken)
        {
            var portfolio = await _portfolioRepository.FindByIdAsync(request.PortfolioId);
            if (portfolio.IsFailure)
            {
                return CommonErrors.NoEntitiesFound;
            }

            var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null || portfolio.Value.UserId.ToString() != userId)
            {
                return CommonErrors.UnauthorizedAccess;
            }

            return _mapper.Map<PortfolioResponseDto>(portfolio.Value);
        }
    }
}
