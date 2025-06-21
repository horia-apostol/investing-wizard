using AutoMapper;
using InvestingWizard.Application.Features.Companies.Queries.GetAllCompaniesByExchangeCode;
using InvestingWizard.Application.Features.Companies.Queries.GetAnalystRatingsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetBalanceSheetByCodeQuery;
using InvestingWizard.Application.Features.Companies.Queries.GetCashFlowByCodeQuery;
using InvestingWizard.Application.Features.Companies.Queries.GetEarningsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetEsgScoresByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetGeneralInformationByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetHighlightsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetHoldersByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetIncomeStatementByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetInsiderTransactionsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetOutstandingSharesByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetSharesStatsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetSplitsDividendsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetTechnicalsByCode;
using InvestingWizard.Application.Features.Companies.Queries.GetValuationByCode;
using InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeByCode;
using InvestingWizard.Domain.Companies;
using InvestingWizard.Domain.Exchanges;
using InvestingWizard.Domain.Prices;
using InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode;
using InvestingWizard.Application.Features.Exchanges.Queries.GetAllExchanges;
using InvestingWizard.Application.Shared.ExternalDtos.LivePrices;
using InvestingWizard.Application.Features.Prices.Queries.GetPricesFromExternalApi;
using InvestingWizard.Application.Features.Prices.Commands.AddPrice;
using InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeDataFromExternalApi;
using InvestingWizard.Domain.Watchlists;
using InvestingWizard.Application.Features.Watchlists.Queries.GetWatchlistById;
using InvestingWizard.Domain.Portfolios;
using InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioById;
using InvestingWizard.Domain.Portfolios.ProfitLossResult;
using InvestingWizard.Application.Features.Portfolios.Queries.GetProfitLoss;
using InvestingWizard.Application.Features.Portfolios.Queries.GetPortfoliosByUserId;
using InvestingWizard.Application.Features.Companies.Queries.GetNameByCode;
using InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioEntriesById;
using InvestingWizard.Application.Features.Portfolios.Queries.GetTransactionsById;
using InvestingWizard.Application.Features.Companies.Queries.GetDividendRateByCode;
using InvestingWizard.Application.Features.Portfolios.Queries.GetDividendById;

namespace InvestingWizard.Application.Shared.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GeneralInformation, GeneralInformationResponseDto>();
            CreateMap<Highlights, HighlightsResponseDto>();
            CreateMap<AnalystRatings, AnalystRatingsResponseDto>();
            CreateMap<Earnings, EarningsResponseDto>();
            CreateMap<EarningsHistory, EarningsHistoryResponseDto>();
            CreateMap<EarningsTrend,  EarningsTrendResponseDto>();
            CreateMap<EarningsAnnual,  EarningsAnnualResponseDto>();
            CreateMap<EsgScores, EsgScoresResponseDto>();
            CreateMap<ActivityInvolvement, ActivityInvolvementResponseDto>();
            CreateMap<IncomeStatementReport, IncomeStatementReportResponseDto>();
            CreateMap<IncomeStatement,  IncomeStatementResponseDto>();
            CreateMap<BalanceSheetReport, BalanceSheetReportResponseDto>();
            CreateMap<BalanceSheet,  BalanceSheetResponseDto>();
            CreateMap<CashFlowReport, CashFlowReportResponseDto>();
            CreateMap<CashFlow, CashFlowResponseDto>();
            CreateMap<Holders, HoldersResponseDto>();
            CreateMap<Holder, HolderResponseDto>();
            CreateMap<InsiderTransactions, InsiderTransactionsResponseDto>();
            CreateMap<InsiderTransaction, InsiderTransactionResponseDto>();
            CreateMap<OutstandingShares, OutstandingSharesResponseDto>();
            CreateMap<OutstandingShare, OutstandingShareResponseDto>();
            CreateMap<SharesStats, SharesStatsResponseDto>();
            CreateMap<SplitsDividends, SplitsDividendsResponseDto>();
            CreateMap<Technicals, TechnicalsResponseDto>();
            CreateMap<Valuation, ValuationResponseDto>();
            CreateMap<Company, CompanyResponseDto>();
            CreateMap<Company, CompanyNameResponseDto>();

            CreateMap<Holiday, HolidayResponseDto>();
            CreateMap<TradingHours, TradingHoursResponseDto>();
            CreateMap<Exchange, ExchangeResponseDto>();
            CreateMap<Exchange, ExchangeNameCodeResponseDto>();
            CreateMap<Exchange, ExchangeDataResponseDto>()
                .ForMember(dest => dest.Holidays, opt => opt.MapFrom(src => src.Holidays))
                .ForMember(dest => dest.TradingHours, opt => opt.MapFrom(src => src.TradingHours));
            CreateMap<Price, PriceResponseDto>();
            CreateMap<AddPriceRequestDto, Price>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.UtcNow)).ReverseMap();
            CreateMap<LivePriceExternalDto, LivePriceResponseDto>();

            CreateMap<Watchlist, WatchlistResponseDto>();

            CreateMap<Portfolio, PortfolioResponseDto>();
            CreateMap<Portfolio, PortfolioIdResponseDto>();
            CreateMap<ProfitLossResult, ProfitLossResultResponseDto>();
            CreateMap<PortfolioEntry, PortfolioEntryResponseDto>();
            CreateMap<Transaction, TransactionResponseDto>();

            CreateMap<decimal, DividendRateResponseDto>();
            CreateMap<decimal, DividendResponseDto>();
            CreateMap<DividendRateResult, DividendRateResponseDto>();
            CreateMap<DividendRateResult, DividendResponseDto>();
        }
    }
}
