using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestingWizard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    ExchangeCode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Ticker = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_Type = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_CountryName = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_CountryISO = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_OpenFigi = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_ISIN = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_LEI = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_CUSIP = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_CIK = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_EmployerCodeNumber = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_FiscalYearEnd = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_IPODate = table.Column<DateOnly>(type: "date", nullable: true),
                    GeneralInformation_InternationalDomestic = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_Sector = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_Industry = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_GicSector = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_GicGroup = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_GicIndustry = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_GicSubIndustry = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_HomeCategory = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_PrimaryTicker = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_IsDelisted = table.Column<bool>(type: "boolean", nullable: true),
                    GeneralInformation_Description = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_Address = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_HeadquartersCountry = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_Phone = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_WebURL = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_LogoURL = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_CeoName = table.Column<string>(type: "text", nullable: true),
                    GeneralInformation_FullTimeEmployees = table.Column<int>(type: "integer", nullable: true),
                    Highlights_MarketCapitalization = table.Column<long>(type: "bigint", nullable: true),
                    Highlights_MarketCapitalizationMln = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_EBITDA = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_PERatio = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_PEGRatio = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_WallStreetTargetPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_BookValue = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_DividendShare = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_DividendYield = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_EarningsShare = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_EPSEstimateCurrentYear = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_EPSEstimateNextYear = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_EPSEstimateNextQuarter = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_EPSEstimateCurrentQuarter = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_MostRecentQuarter = table.Column<DateOnly>(type: "date", nullable: true),
                    Highlights_ProfitMargin = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_OperatingMarginTTM = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_ReturnOnAssetsTTM = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_ReturnOnEquityTTM = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_RevenueTTM = table.Column<long>(type: "bigint", nullable: true),
                    Highlights_RevenuePerShareTTM = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_QuarterlyRevenueGrowthYOY = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_GrossProfitTTM = table.Column<long>(type: "bigint", nullable: true),
                    Highlights_DilutedEpsTTM = table.Column<decimal>(type: "numeric", nullable: true),
                    Highlights_QuarterlyEarningsGrowthYOY = table.Column<decimal>(type: "numeric", nullable: true),
                    Valuation_TrailingPE = table.Column<decimal>(type: "numeric", nullable: true),
                    Valuation_ForwardPE = table.Column<decimal>(type: "numeric", nullable: true),
                    Valuation_PriceSalesTTM = table.Column<decimal>(type: "numeric", nullable: true),
                    Valuation_PriceBookMRQ = table.Column<decimal>(type: "numeric", nullable: true),
                    Valuation_EnterpriseValue = table.Column<long>(type: "bigint", nullable: true),
                    Valuation_EnterpriseValueRevenue = table.Column<decimal>(type: "numeric", nullable: true),
                    Valuation_EnterpriseValueEbitda = table.Column<decimal>(type: "numeric", nullable: true),
                    SharesStats_SharesOutstanding = table.Column<long>(type: "bigint", nullable: true),
                    SharesStats_SharesFloat = table.Column<long>(type: "bigint", nullable: true),
                    SharesStats_PercentInsiders = table.Column<decimal>(type: "numeric", nullable: true),
                    SharesStats_PercentInstitutions = table.Column<decimal>(type: "numeric", nullable: true),
                    SharesStats_SharesShort = table.Column<long>(type: "bigint", nullable: true),
                    SharesStats_SharesShortPriorMonth = table.Column<long>(type: "bigint", nullable: true),
                    SharesStats_ShortRatio = table.Column<decimal>(type: "numeric", nullable: true),
                    SharesStats_ShortPercentOutstanding = table.Column<decimal>(type: "numeric", nullable: true),
                    SharesStats_ShortPercentFloat = table.Column<decimal>(type: "numeric", nullable: true),
                    Technicals_Beta = table.Column<decimal>(type: "numeric", nullable: true),
                    Technicals__52WeekHigh = table.Column<decimal>(type: "numeric", nullable: true),
                    Technicals__52WeekLow = table.Column<decimal>(type: "numeric", nullable: true),
                    Technicals__50DayMA = table.Column<decimal>(type: "numeric", nullable: true),
                    Technicals__200DayMA = table.Column<decimal>(type: "numeric", nullable: true),
                    Technicals_SharesShort = table.Column<long>(type: "bigint", nullable: true),
                    Technicals_SharesShortPriorMonth = table.Column<long>(type: "bigint", nullable: true),
                    Technicals_ShortRatio = table.Column<decimal>(type: "numeric", nullable: true),
                    Technicals_ShortPercentOutstanding = table.Column<decimal>(type: "numeric", nullable: true),
                    Technicals_ShortPercentFloat = table.Column<decimal>(type: "numeric", nullable: true),
                    Technicals_ShortPercent = table.Column<decimal>(type: "numeric", nullable: true),
                    SplitsDividends_ForwardAnnualDividendRate = table.Column<decimal>(type: "numeric", nullable: true),
                    SplitsDividends_ForwardAnnualDividendYield = table.Column<decimal>(type: "numeric", nullable: true),
                    SplitsDividends_PayoutRatio = table.Column<decimal>(type: "numeric", nullable: true),
                    SplitsDividends_DividendDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SplitsDividends_ExDividendDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SplitsDividends_LastSplitFactor = table.Column<string>(type: "text", nullable: true),
                    SplitsDividends_LastSplitDate = table.Column<DateOnly>(type: "date", nullable: true),
                    AnalystRatings_Rating = table.Column<decimal>(type: "numeric", nullable: true),
                    AnalystRatings_TargetPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    AnalystRatings_StrongBuy = table.Column<int>(type: "integer", nullable: true),
                    AnalystRatings_Buy = table.Column<int>(type: "integer", nullable: true),
                    AnalystRatings_Hold = table.Column<int>(type: "integer", nullable: true),
                    AnalystRatings_Sell = table.Column<int>(type: "integer", nullable: true),
                    AnalystRatings_StrongSell = table.Column<int>(type: "integer", nullable: true),
                    EsgScores_Disclaimer = table.Column<string>(type: "text", nullable: true),
                    EsgScores_RatingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EsgScores_TotalEsg = table.Column<decimal>(type: "numeric", nullable: true),
                    EsgScores_TotalEsgPercentile = table.Column<decimal>(type: "numeric", nullable: true),
                    EsgScores_EnvironmentScore = table.Column<decimal>(type: "numeric", nullable: true),
                    EsgScores_EnvironmentScorePercentile = table.Column<decimal>(type: "numeric", nullable: true),
                    EsgScores_SocialScore = table.Column<decimal>(type: "numeric", nullable: true),
                    EsgScores_SocialScorePercentile = table.Column<decimal>(type: "numeric", nullable: true),
                    EsgScores_GovernanceScore = table.Column<decimal>(type: "numeric", nullable: true),
                    EsgScores_GovernanceScorePercentile = table.Column<decimal>(type: "numeric", nullable: true),
                    EsgScores_ControversyLevel = table.Column<int>(type: "integer", nullable: true),
                    Financials_Id = table.Column<Guid>(type: "uuid", nullable: true),
                    Financials_BalanceSheet_CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    Financials_CashFlow_CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    Financials_IncomeStatement_CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Exchanges",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    CurrencyCode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OperatingMIC = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    TimeZone = table.Column<string>(type: "text", nullable: false),
                    TradingHours_Open = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    TradingHours_Close = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    TradingHours_OpenUtc = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    TradingHours_CloseUtc = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    TradingHours_WorkingDays = table.Column<List<string>>(type: "text[]", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SecurityCode = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Open = table.Column<decimal>(type: "numeric", nullable: false),
                    High = table.Column<decimal>(type: "numeric", nullable: false),
                    Low = table.Column<decimal>(type: "numeric", nullable: false),
                    Close = table.Column<decimal>(type: "numeric", nullable: false),
                    Volume = table.Column<long>(type: "bigint", nullable: false),
                    AdjustedClose = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Watchlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SecurityCodes = table.Column<List<string>>(type: "text[]", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watchlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityInvolvement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EsgScoresCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Activity = table.Column<string>(type: "text", nullable: true),
                    Involvement = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityInvolvement", x => new { x.EsgScoresCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_ActivityInvolvement_Companies_EsgScoresCompanyCode",
                        column: x => x.EsgScoresCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies_AnnualShares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OutstandingSharesCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: true),
                    DateFormatted = table.Column<DateOnly>(type: "date", nullable: true),
                    SharesMln = table.Column<string>(type: "text", nullable: true),
                    Shares = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_AnnualShares", x => new { x.OutstandingSharesCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_AnnualShares_Companies_OutstandingSharesCompanyCo~",
                        column: x => x.OutstandingSharesCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies_Funds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HoldersCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    TotalShares = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    CurrentShares = table.Column<long>(type: "bigint", nullable: true),
                    Change = table.Column<long>(type: "bigint", nullable: true),
                    ChangePercentage = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_Funds", x => new { x.HoldersCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_Funds_Companies_HoldersCompanyCode",
                        column: x => x.HoldersCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies_Institutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HoldersCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    TotalShares = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    CurrentShares = table.Column<long>(type: "bigint", nullable: true),
                    Change = table.Column<long>(type: "bigint", nullable: true),
                    ChangePercentage = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_Institutions", x => new { x.HoldersCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_Institutions_Companies_HoldersCompanyCode",
                        column: x => x.HoldersCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies_QuarterlyBalanceSheet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BalanceSheetReportFinancialsCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    FilingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    TotalAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    IntangibleAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    EarningAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    OtherCurrentAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalLiab = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalStockholderEquity = table.Column<decimal>(type: "numeric", nullable: true),
                    DeferredLongTermLiab = table.Column<decimal>(type: "numeric", nullable: true),
                    OtherCurrentLiab = table.Column<decimal>(type: "numeric", nullable: true),
                    CommonStock = table.Column<decimal>(type: "numeric", nullable: true),
                    CapitalStock = table.Column<decimal>(type: "numeric", nullable: true),
                    RetainedEarnings = table.Column<decimal>(type: "numeric", nullable: true),
                    OtherLiab = table.Column<decimal>(type: "numeric", nullable: true),
                    GoodWill = table.Column<decimal>(type: "numeric", nullable: true),
                    OtherAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    Cash = table.Column<decimal>(type: "numeric", nullable: true),
                    CashAndEquivalents = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalCurrentLiabilities = table.Column<decimal>(type: "numeric", nullable: true),
                    CurrentDeferredRevenue = table.Column<decimal>(type: "numeric", nullable: true),
                    NetDebt = table.Column<decimal>(type: "numeric", nullable: true),
                    ShortTermDebt = table.Column<decimal>(type: "numeric", nullable: true),
                    ShortLongTermDebt = table.Column<decimal>(type: "numeric", nullable: true),
                    ShortLongTermDebtTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    OtherStockholderEquity = table.Column<decimal>(type: "numeric", nullable: true),
                    PropertyPlantEquipment = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalCurrentAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    LongTermInvestments = table.Column<decimal>(type: "numeric", nullable: true),
                    NetTangibleAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    ShortTermInvestments = table.Column<decimal>(type: "numeric", nullable: true),
                    NetReceivables = table.Column<decimal>(type: "numeric", nullable: true),
                    LongTermDebt = table.Column<decimal>(type: "numeric", nullable: true),
                    Inventory = table.Column<decimal>(type: "numeric", nullable: true),
                    AccountsPayable = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalPermanentEquity = table.Column<decimal>(type: "numeric", nullable: true),
                    AdditionalPaCodeInCapital = table.Column<decimal>(type: "numeric", nullable: true),
                    NonCurrrentAssetsOther = table.Column<decimal>(type: "numeric", nullable: true),
                    NonCurrentAssetsTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    NonCurrentLiabilitiesOther = table.Column<decimal>(type: "numeric", nullable: true),
                    NonCurrentLiabilitiesTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    NegativeGoodwill = table.Column<decimal>(type: "numeric", nullable: true),
                    Warrants = table.Column<decimal>(type: "numeric", nullable: true),
                    PreferredStockRedeemable = table.Column<decimal>(type: "numeric", nullable: true),
                    CapitalSurpluse = table.Column<decimal>(type: "numeric", nullable: true),
                    LiabilitiesAndStockholdersEquity = table.Column<decimal>(type: "numeric", nullable: true),
                    CashAndShortTermInvestments = table.Column<decimal>(type: "numeric", nullable: true),
                    AccumulatedDepreciation = table.Column<decimal>(type: "numeric", nullable: true),
                    CommonStockSharesOutstanding = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_QuarterlyBalanceSheet", x => new { x.BalanceSheetReportFinancialsCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_QuarterlyBalanceSheet_Companies_BalanceSheetRepor~",
                        column: x => x.BalanceSheetReportFinancialsCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies_QuarterlyCashFlow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CashFlowReportFinancialsCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    FilingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    Investments = table.Column<string>(type: "text", nullable: true),
                    TotalCashFromFinancingActivities = table.Column<string>(type: "text", nullable: true),
                    NetIncome = table.Column<string>(type: "text", nullable: true),
                    ChangeInCash = table.Column<string>(type: "text", nullable: true),
                    Depreciation = table.Column<string>(type: "text", nullable: true),
                    DividendsPaCode = table.Column<string>(type: "text", nullable: true),
                    ChangeToInventory = table.Column<string>(type: "text", nullable: true),
                    ChangeToAccountReceivables = table.Column<string>(type: "text", nullable: true),
                    SalePurchaseOfStock = table.Column<string>(type: "text", nullable: true),
                    OtherCashflowsFromFinancingActivities = table.Column<string>(type: "text", nullable: true),
                    CapitalExpenditures = table.Column<string>(type: "text", nullable: true),
                    TotalCashFromOperatingActivities = table.Column<string>(type: "text", nullable: true),
                    ChangeReceivables = table.Column<string>(type: "text", nullable: true),
                    ChangeInWorkingCapital = table.Column<string>(type: "text", nullable: true),
                    StockBasedCompensation = table.Column<string>(type: "text", nullable: true),
                    OtherNonCashItems = table.Column<string>(type: "text", nullable: true),
                    FreeCashFlow = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_QuarterlyCashFlow", x => new { x.CashFlowReportFinancialsCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_QuarterlyCashFlow_Companies_CashFlowReportFinanci~",
                        column: x => x.CashFlowReportFinancialsCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies_QuarterlyIncomeStatement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IncomeStatementReportFinancialsCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    FilingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    ResearchDevelopment = table.Column<string>(type: "text", nullable: true),
                    IncomeBeforeTax = table.Column<string>(type: "text", nullable: true),
                    NetIncome = table.Column<string>(type: "text", nullable: true),
                    SellingGeneralAdministrative = table.Column<string>(type: "text", nullable: true),
                    GrossProfit = table.Column<string>(type: "text", nullable: true),
                    EBIT = table.Column<string>(type: "text", nullable: true),
                    EBITDA = table.Column<string>(type: "text", nullable: true),
                    DepreciationAndAmortization = table.Column<string>(type: "text", nullable: true),
                    OperatingIncome = table.Column<string>(type: "text", nullable: true),
                    OtherOperatingExpenses = table.Column<string>(type: "text", nullable: true),
                    TaxProvision = table.Column<string>(type: "text", nullable: true),
                    IncomeTaxExpense = table.Column<string>(type: "text", nullable: true),
                    TotalRevenue = table.Column<string>(type: "text", nullable: true),
                    TotalOperatingExpenses = table.Column<string>(type: "text", nullable: true),
                    CostOfRevenue = table.Column<string>(type: "text", nullable: true),
                    TotalOtherIncomeExpenseNet = table.Column<string>(type: "text", nullable: true),
                    NetIncomeFromContinuingOps = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_QuarterlyIncomeStatement", x => new { x.IncomeStatementReportFinancialsCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_QuarterlyIncomeStatement_Companies_IncomeStatemen~",
                        column: x => x.IncomeStatementReportFinancialsCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies_QuarterlyShares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OutstandingSharesCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: true),
                    DateFormatted = table.Column<DateOnly>(type: "date", nullable: true),
                    SharesMln = table.Column<string>(type: "text", nullable: true),
                    Shares = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_QuarterlyShares", x => new { x.OutstandingSharesCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_QuarterlyShares_Companies_OutstandingSharesCompan~",
                        column: x => x.OutstandingSharesCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies_YearlyBalanceSheet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BalanceSheetReportFinancialsCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    FilingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    TotalAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    IntangibleAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    EarningAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    OtherCurrentAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalLiab = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalStockholderEquity = table.Column<decimal>(type: "numeric", nullable: true),
                    DeferredLongTermLiab = table.Column<decimal>(type: "numeric", nullable: true),
                    OtherCurrentLiab = table.Column<decimal>(type: "numeric", nullable: true),
                    CommonStock = table.Column<decimal>(type: "numeric", nullable: true),
                    CapitalStock = table.Column<decimal>(type: "numeric", nullable: true),
                    RetainedEarnings = table.Column<decimal>(type: "numeric", nullable: true),
                    OtherLiab = table.Column<decimal>(type: "numeric", nullable: true),
                    GoodWill = table.Column<decimal>(type: "numeric", nullable: true),
                    OtherAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    Cash = table.Column<decimal>(type: "numeric", nullable: true),
                    CashAndEquivalents = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalCurrentLiabilities = table.Column<decimal>(type: "numeric", nullable: true),
                    CurrentDeferredRevenue = table.Column<decimal>(type: "numeric", nullable: true),
                    NetDebt = table.Column<decimal>(type: "numeric", nullable: true),
                    ShortTermDebt = table.Column<decimal>(type: "numeric", nullable: true),
                    ShortLongTermDebt = table.Column<decimal>(type: "numeric", nullable: true),
                    ShortLongTermDebtTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    OtherStockholderEquity = table.Column<decimal>(type: "numeric", nullable: true),
                    PropertyPlantEquipment = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalCurrentAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    LongTermInvestments = table.Column<decimal>(type: "numeric", nullable: true),
                    NetTangibleAssets = table.Column<decimal>(type: "numeric", nullable: true),
                    ShortTermInvestments = table.Column<decimal>(type: "numeric", nullable: true),
                    NetReceivables = table.Column<decimal>(type: "numeric", nullable: true),
                    LongTermDebt = table.Column<decimal>(type: "numeric", nullable: true),
                    Inventory = table.Column<decimal>(type: "numeric", nullable: true),
                    AccountsPayable = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalPermanentEquity = table.Column<decimal>(type: "numeric", nullable: true),
                    AdditionalPaCodeInCapital = table.Column<decimal>(type: "numeric", nullable: true),
                    NonCurrrentAssetsOther = table.Column<decimal>(type: "numeric", nullable: true),
                    NonCurrentAssetsTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    NonCurrentLiabilitiesOther = table.Column<decimal>(type: "numeric", nullable: true),
                    NonCurrentLiabilitiesTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    NegativeGoodwill = table.Column<decimal>(type: "numeric", nullable: true),
                    Warrants = table.Column<decimal>(type: "numeric", nullable: true),
                    PreferredStockRedeemable = table.Column<decimal>(type: "numeric", nullable: true),
                    CapitalSurpluse = table.Column<decimal>(type: "numeric", nullable: true),
                    LiabilitiesAndStockholdersEquity = table.Column<decimal>(type: "numeric", nullable: true),
                    CashAndShortTermInvestments = table.Column<decimal>(type: "numeric", nullable: true),
                    AccumulatedDepreciation = table.Column<decimal>(type: "numeric", nullable: true),
                    CommonStockSharesOutstanding = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_YearlyBalanceSheet", x => new { x.BalanceSheetReportFinancialsCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_YearlyBalanceSheet_Companies_BalanceSheetReportFi~",
                        column: x => x.BalanceSheetReportFinancialsCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies_YearlyCashFlow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CashFlowReportFinancialsCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    FilingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    Investments = table.Column<string>(type: "text", nullable: true),
                    TotalCashFromFinancingActivities = table.Column<string>(type: "text", nullable: true),
                    NetIncome = table.Column<string>(type: "text", nullable: true),
                    ChangeInCash = table.Column<string>(type: "text", nullable: true),
                    Depreciation = table.Column<string>(type: "text", nullable: true),
                    DividendsPaCode = table.Column<string>(type: "text", nullable: true),
                    ChangeToInventory = table.Column<string>(type: "text", nullable: true),
                    ChangeToAccountReceivables = table.Column<string>(type: "text", nullable: true),
                    SalePurchaseOfStock = table.Column<string>(type: "text", nullable: true),
                    OtherCashflowsFromFinancingActivities = table.Column<string>(type: "text", nullable: true),
                    CapitalExpenditures = table.Column<string>(type: "text", nullable: true),
                    TotalCashFromOperatingActivities = table.Column<string>(type: "text", nullable: true),
                    ChangeReceivables = table.Column<string>(type: "text", nullable: true),
                    ChangeInWorkingCapital = table.Column<string>(type: "text", nullable: true),
                    StockBasedCompensation = table.Column<string>(type: "text", nullable: true),
                    OtherNonCashItems = table.Column<string>(type: "text", nullable: true),
                    FreeCashFlow = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_YearlyCashFlow", x => new { x.CashFlowReportFinancialsCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_YearlyCashFlow_Companies_CashFlowReportFinancials~",
                        column: x => x.CashFlowReportFinancialsCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies_YearlyIncomeStatement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IncomeStatementReportFinancialsCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    FilingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    ResearchDevelopment = table.Column<string>(type: "text", nullable: true),
                    IncomeBeforeTax = table.Column<string>(type: "text", nullable: true),
                    NetIncome = table.Column<string>(type: "text", nullable: true),
                    SellingGeneralAdministrative = table.Column<string>(type: "text", nullable: true),
                    GrossProfit = table.Column<string>(type: "text", nullable: true),
                    EBIT = table.Column<string>(type: "text", nullable: true),
                    EBITDA = table.Column<string>(type: "text", nullable: true),
                    DepreciationAndAmortization = table.Column<string>(type: "text", nullable: true),
                    OperatingIncome = table.Column<string>(type: "text", nullable: true),
                    OtherOperatingExpenses = table.Column<string>(type: "text", nullable: true),
                    TaxProvision = table.Column<string>(type: "text", nullable: true),
                    IncomeTaxExpense = table.Column<string>(type: "text", nullable: true),
                    TotalRevenue = table.Column<string>(type: "text", nullable: true),
                    TotalOperatingExpenses = table.Column<string>(type: "text", nullable: true),
                    CostOfRevenue = table.Column<string>(type: "text", nullable: true),
                    TotalOtherIncomeExpenseNet = table.Column<string>(type: "text", nullable: true),
                    NetIncomeFromContinuingOps = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_YearlyIncomeStatement", x => new { x.IncomeStatementReportFinancialsCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_Companies_YearlyIncomeStatement_Companies_IncomeStatementRe~",
                        column: x => x.IncomeStatementReportFinancialsCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EarningsAnnual",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EarningsCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    EpsActual = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarningsAnnual", x => new { x.EarningsCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_EarningsAnnual_Companies_EarningsCompanyCode",
                        column: x => x.EarningsCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EarningsHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EarningsCompanyCode = table.Column<string>(type: "text", nullable: false),
                    ReportDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    BeforeAfterMarket = table.Column<string>(type: "text", nullable: true),
                    CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    EpsActual = table.Column<decimal>(type: "numeric", nullable: true),
                    EpsEstimate = table.Column<decimal>(type: "numeric", nullable: true),
                    EpsDifference = table.Column<decimal>(type: "numeric", nullable: true),
                    SurprisePercent = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarningsHistory", x => new { x.EarningsCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_EarningsHistory_Companies_EarningsCompanyCode",
                        column: x => x.EarningsCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EarningsTrend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EarningsCompanyCode = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Period = table.Column<string>(type: "text", nullable: true),
                    Growth = table.Column<decimal>(type: "numeric", nullable: true),
                    EarningsEstimateAvg = table.Column<decimal>(type: "numeric", nullable: true),
                    EarningsEstimateLow = table.Column<decimal>(type: "numeric", nullable: true),
                    EarningsEstimateHigh = table.Column<decimal>(type: "numeric", nullable: true),
                    EarningsEstimateYearAgoEps = table.Column<decimal>(type: "numeric", nullable: true),
                    EarningsEstimateNumberOfAnalysts = table.Column<int>(type: "integer", nullable: true),
                    EarningsEstimateGrowth = table.Column<decimal>(type: "numeric", nullable: true),
                    RevenueEstimateAvg = table.Column<decimal>(type: "numeric", nullable: true),
                    RevenueEstimateLow = table.Column<decimal>(type: "numeric", nullable: true),
                    RevenueEstimateHigh = table.Column<decimal>(type: "numeric", nullable: true),
                    RevenueEstimateYearAgoEps = table.Column<decimal>(type: "numeric", nullable: true),
                    RevenueEstimateNumberOfAnalysts = table.Column<int>(type: "integer", nullable: true),
                    RevenueEstimateGrowth = table.Column<decimal>(type: "numeric", nullable: true),
                    EpsTrendCurrent = table.Column<decimal>(type: "numeric", nullable: true),
                    EpsTrend7daysAgo = table.Column<decimal>(type: "numeric", nullable: true),
                    EpsTrend30daysAgo = table.Column<decimal>(type: "numeric", nullable: true),
                    EpsTrend60daysAgo = table.Column<decimal>(type: "numeric", nullable: true),
                    EpsTrend90daysAgo = table.Column<decimal>(type: "numeric", nullable: true),
                    EpsRevisionsUpLast7days = table.Column<int>(type: "integer", nullable: true),
                    EpsRevisionsUpLast30days = table.Column<int>(type: "integer", nullable: true),
                    EpsRevisionsDownLast7days = table.Column<int>(type: "integer", nullable: true),
                    EpsRevisionsDownLast30days = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarningsTrend", x => new { x.EarningsCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_EarningsTrend_Companies_EarningsCompanyCode",
                        column: x => x.EarningsCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsiderTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InsiderTransactionsCompanyCode = table.Column<string>(type: "text", nullable: false),
                    TransactionDate = table.Column<DateOnly>(type: "date", nullable: true),
                    OwnerName = table.Column<string>(type: "text", nullable: true),
                    TransactionCode = table.Column<string>(type: "text", nullable: true),
                    TransactionAmount = table.Column<long>(type: "bigint", nullable: true),
                    TransactionPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    TransactionType = table.Column<string>(type: "text", nullable: true),
                    PostTransactionAmount = table.Column<long>(type: "bigint", nullable: true),
                    SecLink = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsiderTransaction", x => new { x.InsiderTransactionsCompanyCode, x.Id });
                    table.ForeignKey(
                        name: "FK_InsiderTransaction_Companies_InsiderTransactionsCompanyCode",
                        column: x => x.InsiderTransactionsCompanyCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExchangeCode = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    HolidayType = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    CloseTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holiday_Exchanges_ExchangeCode",
                        column: x => x.ExchangeCode,
                        principalTable: "Exchanges",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "PortfolioEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PortfolioId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecurityCode = table.Column<string>(type: "text", nullable: false),
                    TotalUnits = table.Column<decimal>(type: "numeric", nullable: false),
                    AverageUnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyCode = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioEntry", x => new { x.PortfolioId, x.Id });
                    table.ForeignKey(
                        name: "FK_PortfolioEntry_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PortfolioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Units = table.Column<decimal>(type: "numeric", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    AmountInUserCurrency = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionCurrencyCode = table.Column<string>(type: "text", nullable: false),
                    UserCurrencyCode = table.Column<string>(type: "text", nullable: false),
                    SecurityCode = table.Column<string>(type: "text", nullable: false),
                    BrokerIsResident = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => new { x.PortfolioId, x.Id });
                    table.ForeignKey(
                        name: "FK_Transaction_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holiday_ExchangeCode",
                table: "Holiday",
                column: "ExchangeCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityInvolvement");

            migrationBuilder.DropTable(
                name: "Companies_AnnualShares");

            migrationBuilder.DropTable(
                name: "Companies_Funds");

            migrationBuilder.DropTable(
                name: "Companies_Institutions");

            migrationBuilder.DropTable(
                name: "Companies_QuarterlyBalanceSheet");

            migrationBuilder.DropTable(
                name: "Companies_QuarterlyCashFlow");

            migrationBuilder.DropTable(
                name: "Companies_QuarterlyIncomeStatement");

            migrationBuilder.DropTable(
                name: "Companies_QuarterlyShares");

            migrationBuilder.DropTable(
                name: "Companies_YearlyBalanceSheet");

            migrationBuilder.DropTable(
                name: "Companies_YearlyCashFlow");

            migrationBuilder.DropTable(
                name: "Companies_YearlyIncomeStatement");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "EarningsAnnual");

            migrationBuilder.DropTable(
                name: "EarningsHistory");

            migrationBuilder.DropTable(
                name: "EarningsTrend");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "InsiderTransaction");

            migrationBuilder.DropTable(
                name: "PortfolioEntry");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Watchlists");

            migrationBuilder.DropTable(
                name: "Exchanges");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Portfolios");
        }
    }
}
