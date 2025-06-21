using InvestingWizard.Application.Shared.ExternalDtos.Companies;
using InvestingWizard.Application.Shared.ExternalDtos.Exchanges;
using InvestingWizard.Application.Shared.ExternalDtos.Prices;
using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Domain.Companies;
using InvestingWizard.Domain.Exchanges;
using InvestingWizard.Domain.Prices;

namespace InvestingWizard.Infrastructure.Services.Mappers
{
    public class EntityMapper : IEntityMapper
    {
        public static DateOnly? SafeParseDateOnly(string? dateString)
        {
            if (DateTime.TryParse(dateString, out var result))
            {
                return DateOnly.FromDateTime(result);
            }
            return null;
        }

        public Company Map(string companyCode, string exchangeCode, CompanyExternalDto companyData)
        {
            var newCompany = Company.Create(companyCode, exchangeCode);
            if (companyData.General != null)
            {
                if (companyData.General.Code != null)
                {
                    newCompany.SetTicker(companyData.General.Code);
                }
                if (companyData.General.Name != null)
                {
                    newCompany.SetName(companyData.General.Name);
                }

                newCompany.SetGeneralInformation(new GeneralInformation
                {

                    Type = companyData.General?.Type,
                    CurrencyCode = companyData.General?.CurrencyCode,
                    CountryName = companyData.General?.CountryName,
                    CountryISO = companyData.General?.CountryISO,
                    OpenFigi = companyData.General?.OpenFigi,
                    ISIN = companyData.General?.ISIN,
                    LEI = companyData.General?.LEI,
                    CUSIP = companyData.General?.CUSIP,
                    CIK = companyData.General?.CIK,
                    PrimaryTicker = companyData.General?.PrimaryTicker,
                    EmployerCodeNumber = companyData.General?.EmployerCodeNumber,
                    FiscalYearEnd = companyData.General?.FiscalYearEnd,
                    IPODate = SafeParseDateOnly(companyData.General?.IPODate),
                    InternationalDomestic = companyData.General?.InternationalDomestic,
                    Sector = companyData.General?.Sector,
                    Industry = companyData.General?.Industry,
                    GicSector = companyData.General?.GicSector,
                    GicGroup = companyData.General?.GicGroup,
                    GicIndustry = companyData.General?.GicIndustry,
                    GicSubIndustry = companyData.General?.GicSubIndustry,
                    HomeCategory = companyData.General?.HomeCategory,
                    IsDelisted = companyData.General?.IsDelisted,
                    Description = companyData.General?.Description,
                    Address = companyData.General?.Address,
                    HeadquartersCountry = companyData.General?.AddressData?.Country,
                    Phone = companyData.General?.Phone,
                    WebURL = companyData.General?.WebURL,
                    LogoURL = companyData.General?.LogoURL,
                    CeoName = companyData.General?.Officers != null && companyData.General.Officers.ContainsKey("0") ? companyData.General.Officers["0"].Name : null,
                    FullTimeEmployees = companyData.General?.FullTimeEmployees
                });
            }

            if (companyData.Highlights != null)
            {
                newCompany.SetHighlights(new Highlights
                {
                    MarketCapitalization = companyData.Highlights?.MarketCapitalization,
                    MarketCapitalizationMln = companyData.Highlights?.MarketCapitalizationMln,
                    EBITDA = companyData.Highlights?.EBITDA,
                    PERatio = companyData.Highlights?.PERatio,
                    PEGRatio = companyData.Highlights?.PEGRatio,
                    WallStreetTargetPrice = companyData.Highlights?.WallStreetTargetPrice,
                    BookValue = companyData.Highlights?.BookValue,
                    DividendShare = companyData.Highlights?.DividendShare,
                    DividendYield = companyData.Highlights?.DividendYield,
                    EarningsShare = companyData.Highlights?.EarningsShare,
                    EPSEstimateCurrentYear = companyData.Highlights?.EPSEstimateCurrentYear,
                    EPSEstimateNextYear = companyData.Highlights?.EPSEstimateNextYear,
                    EPSEstimateNextQuarter = companyData.Highlights?.EPSEstimateNextQuarter,
                    EPSEstimateCurrentQuarter = companyData.Highlights?.EPSEstimateCurrentQuarter,
                    MostRecentQuarter = SafeParseDateOnly(companyData.Highlights?.MostRecentQuarter),
                    ProfitMargin = companyData.Highlights?.ProfitMargin,
                    OperatingMarginTTM = companyData.Highlights?.OperatingMarginTTM,
                    ReturnOnAssetsTTM = companyData.Highlights?.ReturnOnAssetsTTM,
                    ReturnOnEquityTTM = companyData.Highlights?.ReturnOnEquityTTM,
                    RevenueTTM = companyData.Highlights?.RevenueTTM,
                    RevenuePerShareTTM = companyData.Highlights?.RevenuePerShareTTM,
                    QuarterlyRevenueGrowthYOY = companyData.Highlights?.QuarterlyRevenueGrowthYOY,
                    GrossProfitTTM = companyData.Highlights?.GrossProfitTTM,
                    DilutedEpsTTM = companyData.Highlights?.DilutedEpsTTM,
                    QuarterlyEarningsGrowthYOY = companyData.Highlights?.QuarterlyEarningsGrowthYOY
                });
            }

            if (companyData.Valuation != null)
            {
                newCompany.SetValuation(new Valuation
                {
                    TrailingPE = companyData.Valuation?.TrailingPE,
                    ForwardPE = companyData.Valuation?.ForwardPE,
                    PriceSalesTTM = companyData.Valuation?.PriceSalesTTM,
                    PriceBookMRQ = companyData.Valuation?.PriceBookMRQ,
                    EnterpriseValue = companyData.Valuation?.EnterpriseValue,
                    EnterpriseValueRevenue = companyData.Valuation?.EnterpriseValueRevenue,
                    EnterpriseValueEbitda = companyData.Valuation?.EnterpriseValueEbitda
                });
            }

            if (companyData.SharesStats != null)
            {
                newCompany.SetSharesStats(new SharesStats
                {
                    SharesOutstanding = companyData.SharesStats?.SharesOutstanding,
                    SharesFloat = companyData.SharesStats?.SharesFloat,
                    PercentInsiders = companyData.SharesStats?.PercentInsiders,
                    PercentInstitutions = companyData.SharesStats?.PercentInstitutions,
                    SharesShort = companyData.SharesStats?.SharesShort,
                    SharesShortPriorMonth = companyData.SharesStats?.SharesShortPriorMonth,
                    ShortRatio = companyData.SharesStats?.ShortRatio,
                    ShortPercentOutstanding = companyData.SharesStats?.ShortPercentOutstanding,
                    ShortPercentFloat = companyData.SharesStats?.ShortPercentFloat
                });
            }

            if (companyData.Technicals != null)
            {
                newCompany.SetTechnicals(new Technicals
                {
                    Beta = companyData.Technicals?.Beta,
                    _52WeekHigh = companyData.Technicals?._52WeekHigh,
                    _52WeekLow = companyData.Technicals?._52WeekLow,
                    _50DayMA = companyData.Technicals?._50DayMA,
                    _200DayMA = companyData.Technicals?._200DayMA,
                    SharesShort = companyData.Technicals?.SharesShort,
                    SharesShortPriorMonth = companyData.Technicals?.SharesShortPriorMonth,
                    ShortRatio = companyData.Technicals?.ShortRatio,
                    ShortPercent = companyData.Technicals?.ShortPercent
                });
            }

            if (companyData.SharesStats != null)
            {
                newCompany.SetSplitsDividends(new SplitsDividends
                {
                    ForwardAnnualDividendRate = companyData.SplitsDividends?.ForwardAnnualDividendRate,
                    ForwardAnnualDividendYield = companyData.SplitsDividends?.ForwardAnnualDividendYield,
                    PayoutRatio = companyData.SplitsDividends?.PayoutRatio,
                    DividendDate = SafeParseDateOnly(companyData.SplitsDividends?.DividendDate),
                    ExDividendDate = SafeParseDateOnly(companyData.SplitsDividends?.ExDividendDate),
                    LastSplitFactor = companyData.SplitsDividends?.LastSplitFactor,
                    LastSplitDate = SafeParseDateOnly(companyData.SplitsDividends?.LastSplitDate)
                });
            }

            if (companyData.AnalystRatings != null)
            {
                newCompany.SetAnalystRatings(new AnalystRatings
                {
                    Rating = companyData.AnalystRatings?.Rating,
                    TargetPrice = companyData.AnalystRatings?.TargetPrice,
                    StrongBuy = companyData.AnalystRatings?.StrongBuy,
                    Buy = companyData.AnalystRatings?.Buy,
                    Hold = companyData.AnalystRatings?.Hold,
                    Sell = companyData.AnalystRatings?.Sell,
                    StrongSell = companyData.AnalystRatings?.StrongSell
                });
            }

            if (companyData.Holders != null)
            {
                newCompany.SetHolders(new Holders
                {
                    Institutions = companyData.Holders?.Institutions?.Select(kv => new Holder
                    {
                        Name = kv.Value.Name,
                        Date = SafeParseDateOnly(kv.Value.Date),
                        TotalShares = kv.Value.TotalShares ?? 0m,
                        TotalAssets = kv.Value.TotalAssets ?? 0m,
                        CurrentShares = kv.Value.CurrentShares ?? 0,
                        Change = kv.Value.Change ?? 0,
                        ChangePercentage = kv.Value.ChangePercentage ?? 0m
                    }).ToList(),

                    Funds = companyData.Holders?.Funds?.Select(kv => new Holder
                    {
                        Name = kv.Value.Name,
                        Date = SafeParseDateOnly(kv.Value.Date),
                        TotalShares = kv.Value.TotalShares ?? 0m,
                        TotalAssets = kv.Value.TotalAssets ?? 0m,
                        CurrentShares = kv.Value.CurrentShares ?? 0,
                        Change = kv.Value.Change ?? 0,
                        ChangePercentage = kv.Value.ChangePercentage ?? 0m
                    }).ToList()
                });
            }

            if (companyData.InsiderTransactions != null)
            {
                newCompany.SetInsiderTransactions(new InsiderTransactions
                {
                    Transactions = companyData.InsiderTransactions?.Select(t => new InsiderTransaction
                    {
                        TransactionDate = SafeParseDateOnly(t.Value.TransactionDate),
                        OwnerName = t.Value.OwnerName,
                        TransactionCode = t.Value.TransactionCode,
                        TransactionAmount = t.Value.TransactionAmount,
                        TransactionPrice = t.Value.TransactionPrice,
                        TransactionType = t.Value.TransactionAcquiredDisposed,
                        PostTransactionAmount = (long)Convert.ToDouble(t.Value.PostTransactionAmount),
                        SecLink = t.Value.SecLink

                    }).ToList()
                });
            }


            if (companyData.EsgScores != null)
            {
                newCompany.SetEsgScores(new EsgScores
                {
                    Disclaimer = companyData.EsgScores.Disclaimer,
                    RatingDate = SafeParseDateOnly(companyData.EsgScores.RatingDate),
                    TotalEsg = companyData.EsgScores.TotalEsg,
                    TotalEsgPercentile = companyData.EsgScores.TotalEsgPercentile,
                    EnvironmentScore = companyData.EsgScores.EnvironmentScore,
                    EnvironmentScorePercentile = companyData.EsgScores.EnvironmentScorePercentile,
                    SocialScore = companyData.EsgScores.SocialScore,
                    SocialScorePercentile = companyData.EsgScores.SocialScorePercentile,
                    GovernanceScore = companyData.EsgScores.GovernanceScore,
                    GovernanceScorePercentile = companyData.EsgScores.GovernanceScorePercentile,
                    ControversyLevel = companyData.EsgScores.ControversyLevel,
                    ActivitiesInvolvement = companyData.EsgScores.ActivitiesInvolvement?
                    .Where(kv => !string.IsNullOrEmpty(kv.Value.Activity))
                    .Select(kv => new ActivityInvolvement
                    {
                        Activity = kv.Value.Activity,
                        Involvement = kv.Value.Involvement
                    }).ToList()
                });
            }


            if (companyData.OutstandingShares != null)
            {
                newCompany.SetOutstandingShares(new OutstandingShares
                {
                    AnnualShares = companyData.OutstandingShares?.Annual?.Select(s => new OutstandingShare
                    {
                        Year = s.Value.Date,
                        DateFormatted = SafeParseDateOnly(s.Value.DateFormatted),
                        SharesMln = s.Value.SharesMln,
                        Shares = s.Value.Shares
                    }).ToList(),

                    QuarterlyShares = companyData.OutstandingShares?.Quarterly?.Select(s => new OutstandingShare
                    {
                        Year = s.Value.Date,
                        DateFormatted = SafeParseDateOnly(s.Value.DateFormatted),
                        SharesMln = s.Value.SharesMln,
                        Shares = s.Value.Shares
                    }).ToList()
                });
            }

            if (companyData.Earnings != null)
            {
                newCompany.SetEarnings(new Earnings
                {
                    EarningsHistories = companyData.Earnings?.History?.Select(kv => new EarningsHistory
                    {
                        ReportDate = SafeParseDateOnly(kv.Value.ReportDate),
                        Date = SafeParseDateOnly(kv.Value.Date),
                        BeforeAfterMarket = kv.Value.BeforeAfterMarket,
                        CurrencyCode = kv.Value.Currency,
                        EpsActual = kv.Value.EpsActual,
                        EpsEstimate = kv.Value.EpsEstimate,
                        EpsDifference = kv.Value.EpsDifference,
                        SurprisePercent = kv.Value.SurprisePercent
                    }).ToList(),

                    EarningsTrends = companyData.Earnings?.Trend?.Select(kv => new EarningsTrend
                    {
                        Date = SafeParseDateOnly(kv.Value.Date),
                        Period = kv.Value.Period,
                        Growth = (decimal)Convert.ToDouble(kv.Value.Growth),
                        EarningsEstimateAvg = (decimal)Convert.ToDouble(kv.Value.EarningsEstimateAvg),
                        EarningsEstimateLow = (decimal)Convert.ToDouble(kv.Value.EarningsEstimateLow),
                        EarningsEstimateHigh = (decimal)Convert.ToDouble(kv.Value.EarningsEstimateHigh),
                        EarningsEstimateYearAgoEps = (decimal)Convert.ToDouble(kv.Value.EarningsEstimateYearAgoEps),
                        EarningsEstimateNumberOfAnalysts = (int)Convert.ToDouble(kv.Value.EarningsEstimateNumberOfAnalysts),
                        EarningsEstimateGrowth = (decimal)Convert.ToDouble(kv.Value.EarningsEstimateGrowth),
                        RevenueEstimateAvg = (decimal)Convert.ToDouble(kv.Value.RevenueEstimateAvg),
                        RevenueEstimateLow = (decimal)Convert.ToDouble(kv.Value.RevenueEstimateLow),
                        RevenueEstimateHigh = (decimal)Convert.ToDouble(kv.Value.RevenueEstimateHigh),
                        RevenueEstimateYearAgoEps = (decimal)Convert.ToDouble(kv.Value.RevenueEstimateYearAgoEps),
                        RevenueEstimateNumberOfAnalysts = (int)Convert.ToDouble(kv.Value.RevenueEstimateNumberOfAnalysts),
                        RevenueEstimateGrowth = (decimal)Convert.ToDouble(kv.Value.RevenueEstimateGrowth),
                        EpsTrendCurrent = (decimal)Convert.ToDouble(kv.Value.EpsTrendCurrent),
                        EpsTrend7daysAgo = (decimal)Convert.ToDouble(kv.Value.EpsTrend7daysAgo),
                        EpsTrend30daysAgo = (decimal)Convert.ToDouble(kv.Value.EpsTrend30daysAgo),
                        EpsTrend60daysAgo = (decimal)Convert.ToDouble(kv.Value.EpsTrend60daysAgo),
                        EpsTrend90daysAgo = (decimal)Convert.ToDouble(kv.Value.EpsTrend90daysAgo),
                        EpsRevisionsUpLast7days = (int)Convert.ToDouble(kv.Value.EpsRevisionsUpLast7days),
                        EpsRevisionsUpLast30days = (int)Convert.ToDouble(kv.Value.EpsRevisionsUpLast30days),
                        EpsRevisionsDownLast7days = (int)Convert.ToDouble(kv.Value.EpsRevisionsDownLast7days),
                        EpsRevisionsDownLast30days = (int)Convert.ToDouble(kv.Value.EpsRevisionsDownLast30days)
                    }).ToList(),

                    EarningsAnnuals = companyData.Earnings?.Annual?.Select(kv => new EarningsAnnual
                    {
                        Date = SafeParseDateOnly(kv.Value.Date),
                        EpsActual = kv.Value.EpsActual
                    }).ToList()
                });
            }

            var financials = new Financials();
            if (companyData?.Financials != null)
            {
                if (companyData.Financials.BalanceSheet != null)
                {
                    financials.BalanceSheet = new BalanceSheetReport
                    {
                        CurrencyCode = companyData.Financials.BalanceSheet.CurrencySymbol,
                        QuarterlyBalanceSheet = companyData.Financials.BalanceSheet.Quarterly?.Select(kv => new BalanceSheet
                        {
                            Date = SafeParseDateOnly(kv.Value.Date),
                            FilingDate = SafeParseDateOnly(kv.Value.FilingDate),
                            CurrencyCode = kv.Value.CurrencySymbol,
                            TotalAssets = (decimal)Convert.ToDouble(kv.Value.TotalAssets),
                            IntangibleAssets = (decimal)Convert.ToDouble(kv.Value.IntangibleAssets),
                            EarningAssets = (decimal)Convert.ToDouble(kv.Value.EarningAssets),
                            OtherCurrentAssets = (decimal)Convert.ToDouble(kv.Value.OtherCurrentAssets),
                            TotalLiab = (decimal)Convert.ToDouble(kv.Value.TotalLiab),
                            TotalStockholderEquity = (decimal)Convert.ToDouble(kv.Value.TotalStockholderEquity),
                            DeferredLongTermLiab = (decimal)Convert.ToDouble(kv.Value.DeferredLongTermLiab),
                            OtherCurrentLiab = (decimal)Convert.ToDouble(kv.Value.OtherCurrentLiab),
                            CommonStock = (decimal)Convert.ToDouble(kv.Value.CommonStock),
                            CapitalStock = (decimal)Convert.ToDouble(kv.Value.CapitalStock),
                            RetainedEarnings = (decimal)Convert.ToDouble(kv.Value.RetainedEarnings),
                            OtherLiab = (decimal)Convert.ToDouble(kv.Value.OtherLiab),
                            GoodWill = (decimal)Convert.ToDouble(kv.Value.GoodWill),
                            OtherAssets = (decimal)Convert.ToDouble(kv.Value.OtherAssets),
                            Cash = (decimal)Convert.ToDouble(kv.Value.Cash),
                            CashAndEquivalents = (decimal)Convert.ToDouble(kv.Value.CashAndEquivalents),
                            TotalCurrentLiabilities = (decimal)Convert.ToDouble(kv.Value.TotalCurrentLiabilities),
                            CurrentDeferredRevenue = (decimal)Convert.ToDouble(kv.Value.CurrentDeferredRevenue),
                            NetDebt = (decimal)Convert.ToDouble(kv.Value.NetDebt),
                            ShortTermDebt = (decimal)Convert.ToDouble(kv.Value.ShortTermDebt),
                            ShortLongTermDebt = (decimal)Convert.ToDouble(kv.Value.ShortLongTermDebt),
                            ShortLongTermDebtTotal = (decimal)Convert.ToDouble(kv.Value.ShortLongTermDebtTotal),
                            OtherStockholderEquity = (decimal)Convert.ToDouble(kv.Value.OtherStockholderEquity),
                            PropertyPlantEquipment = (decimal)Convert.ToDouble(kv.Value.PropertyPlantEquipment),
                            TotalCurrentAssets = (decimal)Convert.ToDouble(kv.Value.TotalCurrentAssets),
                            LongTermInvestments = (decimal)Convert.ToDouble(kv.Value.LongTermInvestments),
                            NetTangibleAssets = (decimal)Convert.ToDouble(kv.Value.NetTangibleAssets),
                            ShortTermInvestments = (decimal)Convert.ToDouble(kv.Value.ShortTermInvestments),
                            NetReceivables = (decimal)Convert.ToDouble(kv.Value.NetReceivables),
                            LongTermDebt = (decimal)Convert.ToDouble(kv.Value.LongTermDebt),
                            Inventory = (decimal)Convert.ToDouble(kv.Value.Inventory),
                            AccountsPayable = (decimal)Convert.ToDouble(kv.Value.AccountsPayable),
                            TotalPermanentEquity = (decimal)Convert.ToDouble(kv.Value.TotalPermanentEquity),
                            AdditionalPaCodeInCapital = (decimal)Convert.ToDouble(kv.Value.AdditionalPaCodeInCapital),
                            NonCurrrentAssetsOther = (decimal)Convert.ToDouble(kv.Value.NonCurrrentAssetsOther),
                            NonCurrentAssetsTotal = (decimal)Convert.ToDouble(kv.Value.NonCurrentAssetsTotal),
                            NonCurrentLiabilitiesOther = (decimal)Convert.ToDouble(kv.Value.NonCurrentLiabilitiesOther),
                            NonCurrentLiabilitiesTotal = (decimal)Convert.ToDouble(kv.Value.NonCurrentLiabilitiesTotal),
                            NegativeGoodwill = (decimal)Convert.ToDouble(kv.Value.NegativeGoodwill),
                            Warrants = (decimal)Convert.ToDouble(kv.Value.Warrants),
                            PreferredStockRedeemable = (decimal)Convert.ToDouble(kv.Value.PreferredStockRedeemable),
                            CapitalSurpluse = (decimal)Convert.ToDouble(kv.Value.CapitalSurpluse),
                            LiabilitiesAndStockholdersEquity = (decimal)Convert.ToDouble(kv.Value.LiabilitiesAndStockholdersEquity),
                            CashAndShortTermInvestments = (decimal)Convert.ToDouble(kv.Value.CashAndShortTermInvestments),
                            AccumulatedDepreciation = (decimal)Convert.ToDouble(kv.Value.AccumulatedDepreciation),
                            CommonStockSharesOutstanding = (decimal)Convert.ToDouble(kv.Value.CommonStockSharesOutstanding)

                        }).ToList(),
                        YearlyBalanceSheet = companyData.Financials.BalanceSheet.Yearly?.Select(kv => new BalanceSheet
                        {
                            Date = SafeParseDateOnly(kv.Value.Date),
                            FilingDate = SafeParseDateOnly(kv.Value.FilingDate),
                            CurrencyCode = kv.Value.CurrencySymbol,
                            TotalAssets = (decimal)Convert.ToDouble(kv.Value.TotalAssets),
                            IntangibleAssets = (decimal)Convert.ToDouble(kv.Value.IntangibleAssets),
                            EarningAssets = (decimal)Convert.ToDouble(kv.Value.EarningAssets),
                            OtherCurrentAssets = (decimal)Convert.ToDouble(kv.Value.OtherCurrentAssets),
                            TotalLiab = (decimal)Convert.ToDouble(kv.Value.TotalLiab),
                            TotalStockholderEquity = (decimal)Convert.ToDouble(kv.Value.TotalStockholderEquity),
                            DeferredLongTermLiab = (decimal)Convert.ToDouble(kv.Value.DeferredLongTermLiab),
                            OtherCurrentLiab = (decimal)Convert.ToDouble(kv.Value.OtherCurrentLiab),
                            CommonStock = (decimal)Convert.ToDouble(kv.Value.CommonStock),
                            CapitalStock = (decimal)Convert.ToDouble(kv.Value.CapitalStock),
                            RetainedEarnings = (decimal)Convert.ToDouble(kv.Value.RetainedEarnings),
                            OtherLiab = (decimal)Convert.ToDouble(kv.Value.OtherLiab),
                            GoodWill = (decimal)Convert.ToDouble(kv.Value.GoodWill),
                            OtherAssets = (decimal)Convert.ToDouble(kv.Value.OtherAssets),
                            Cash = (decimal)Convert.ToDouble(kv.Value.Cash),
                            CashAndEquivalents = (decimal)Convert.ToDouble(kv.Value.CashAndEquivalents),
                            TotalCurrentLiabilities = (decimal)Convert.ToDouble(kv.Value.TotalCurrentLiabilities),
                            CurrentDeferredRevenue = (decimal)Convert.ToDouble(kv.Value.CurrentDeferredRevenue),
                            NetDebt = (decimal)Convert.ToDouble(kv.Value.NetDebt),
                            ShortTermDebt = (decimal)Convert.ToDouble(kv.Value.ShortTermDebt),
                            ShortLongTermDebt = (decimal)Convert.ToDouble(kv.Value.ShortLongTermDebt),
                            ShortLongTermDebtTotal = (decimal)Convert.ToDouble(kv.Value.ShortLongTermDebtTotal),
                            OtherStockholderEquity = (decimal)Convert.ToDouble(kv.Value.OtherStockholderEquity),
                            PropertyPlantEquipment = (decimal)Convert.ToDouble(kv.Value.PropertyPlantEquipment),
                            TotalCurrentAssets = (decimal)Convert.ToDouble(kv.Value.TotalCurrentAssets),
                            LongTermInvestments = (decimal)Convert.ToDouble(kv.Value.LongTermInvestments),
                            NetTangibleAssets = (decimal)Convert.ToDouble(kv.Value.NetTangibleAssets),
                            ShortTermInvestments = (decimal)Convert.ToDouble(kv.Value.ShortTermInvestments),
                            NetReceivables = (decimal)Convert.ToDouble(kv.Value.NetReceivables),
                            LongTermDebt = (decimal)Convert.ToDouble(kv.Value.LongTermDebt),
                            Inventory = (decimal)Convert.ToDouble(kv.Value.Inventory),
                            AccountsPayable = (decimal)Convert.ToDouble(kv.Value.AccountsPayable),
                            TotalPermanentEquity = (decimal)Convert.ToDouble(kv.Value.TotalPermanentEquity),
                            AdditionalPaCodeInCapital = (decimal)Convert.ToDouble(kv.Value.AdditionalPaCodeInCapital),
                            NonCurrrentAssetsOther = (decimal)Convert.ToDouble(kv.Value.NonCurrrentAssetsOther),
                            NonCurrentAssetsTotal = (decimal)Convert.ToDouble(kv.Value.NonCurrentAssetsTotal),
                            NonCurrentLiabilitiesOther = (decimal)Convert.ToDouble(kv.Value.NonCurrentLiabilitiesOther),
                            NonCurrentLiabilitiesTotal = (decimal)Convert.ToDouble(kv.Value.NonCurrentLiabilitiesTotal),
                            NegativeGoodwill = (decimal)Convert.ToDouble(kv.Value.NegativeGoodwill),
                            Warrants = (decimal)Convert.ToDouble(kv.Value.Warrants),
                            PreferredStockRedeemable = (decimal)Convert.ToDouble(kv.Value.PreferredStockRedeemable),
                            CapitalSurpluse = (decimal)Convert.ToDouble(kv.Value.CapitalSurpluse),
                            LiabilitiesAndStockholdersEquity = (decimal)Convert.ToDouble(kv.Value.LiabilitiesAndStockholdersEquity),
                            CashAndShortTermInvestments = (decimal)Convert.ToDouble(kv.Value.CashAndShortTermInvestments),
                            AccumulatedDepreciation = (decimal)Convert.ToDouble(kv.Value.AccumulatedDepreciation),
                            CommonStockSharesOutstanding = (decimal)Convert.ToDouble(kv.Value.CommonStockSharesOutstanding)
                        }).ToList()
                    };
                }
                if (companyData.Financials.IncomeStatement != null)
                {
                    financials.IncomeStatement = new IncomeStatementReport
                    {
                        CurrencyCode = companyData.Financials.IncomeStatement.CurrencySymbol,
                        QuarterlyIncomeStatement = companyData.Financials.IncomeStatement.Quarterly?.Select(kv => new IncomeStatement
                        {
                            Date = SafeParseDateOnly(kv.Value.Date),
                            FilingDate = SafeParseDateOnly(kv.Value.FilingDate),
                            CurrencyCode = kv.Value.CurrencySymbol,
                            ResearchDevelopment = kv.Value.ResearchDevelopment,
                            IncomeBeforeTax = kv.Value.IncomeBeforeTax,
                            NetIncome = kv.Value.NetIncome,
                            SellingGeneralAdministrative = kv.Value.SellingGeneralAdministrative,
                            GrossProfit = kv.Value.GrossProfit,
                            EBIT = kv.Value.EBIT,
                            EBITDA = kv.Value.EBITDA,
                            DepreciationAndAmortization = kv.Value.DepreciationAndAmortization,
                            OperatingIncome = kv.Value.OperatingIncome,
                            OtherOperatingExpenses = kv.Value.OtherOperatingExpenses,
                            TaxProvision = kv.Value.TaxProvision,
                            IncomeTaxExpense = kv.Value.IncomeTaxExpense,
                            TotalRevenue = kv.Value.TotalRevenue,
                            TotalOperatingExpenses = kv.Value.TotalOperatingExpenses,
                            CostOfRevenue = kv.Value.CostOfRevenue,
                            TotalOtherIncomeExpenseNet = kv.Value.TotalOtherIncomeExpenseNet,
                            NetIncomeFromContinuingOps = kv.Value.NetIncomeFromContinuingOps

                        }).ToList(),
                        YearlyIncomeStatement = companyData.Financials.IncomeStatement.Yearly?.Select(kv => new IncomeStatement
                        {
                            Date = SafeParseDateOnly(kv.Value.Date),
                            FilingDate = SafeParseDateOnly(kv.Value.FilingDate),
                            CurrencyCode = kv.Value.CurrencySymbol,
                            ResearchDevelopment = kv.Value.ResearchDevelopment,
                            IncomeBeforeTax = kv.Value.IncomeBeforeTax,
                            NetIncome = kv.Value.NetIncome,
                            SellingGeneralAdministrative = kv.Value.SellingGeneralAdministrative,
                            GrossProfit = kv.Value.GrossProfit,
                            EBIT = kv.Value.EBIT,
                            EBITDA = kv.Value.EBITDA,
                            DepreciationAndAmortization = kv.Value.DepreciationAndAmortization,
                            OperatingIncome = kv.Value.OperatingIncome,
                            OtherOperatingExpenses = kv.Value.OtherOperatingExpenses,
                            TaxProvision = kv.Value.TaxProvision,
                            IncomeTaxExpense = kv.Value.IncomeTaxExpense,
                            TotalRevenue = kv.Value.TotalRevenue,
                            TotalOperatingExpenses = kv.Value.TotalOperatingExpenses,
                            CostOfRevenue = kv.Value.CostOfRevenue,
                            TotalOtherIncomeExpenseNet = kv.Value.TotalOtherIncomeExpenseNet,
                            NetIncomeFromContinuingOps = kv.Value.NetIncomeFromContinuingOps

                        }).ToList()
                    };
                }
                if (companyData.Financials.CashFlow != null)
                {
                    financials.CashFlow = new CashFlowReport
                    {
                        CurrencyCode = companyData.Financials.CashFlow.CurrencySymbol,
                        QuarterlyCashFlow = companyData.Financials.CashFlow.Quarterly?.Select(kv => new CashFlow
                        {
                            Date = SafeParseDateOnly(kv.Value.Date),
                            FilingDate = SafeParseDateOnly(kv.Value.FilingDate),
                            CurrencyCode = kv.Value.CurrencySymbol,
                            Investments = kv.Value.Investments,
                            TotalCashFromFinancingActivities = kv.Value.TotalCashFromFinancingActivities,
                            NetIncome = kv.Value.NetIncome,
                            ChangeInCash = kv.Value.ChangeInCash,
                            Depreciation = kv.Value.Depreciation,
                            DividendsPaCode = kv.Value.DividendsPaCode,
                            ChangeToInventory = kv.Value.ChangeToInventory,
                            ChangeToAccountReceivables = kv.Value.ChangeToAccountReceivables,
                            SalePurchaseOfStock = kv.Value.SalePurchaseOfStock,
                            OtherCashflowsFromFinancingActivities = kv.Value.OtherCashflowsFromFinancingActivities,
                            CapitalExpenditures = kv.Value.CapitalExpenditures,
                            TotalCashFromOperatingActivities = kv.Value.TotalCashFromOperatingActivities,
                            ChangeReceivables = kv.Value.ChangeReceivables,
                            ChangeInWorkingCapital = kv.Value.ChangeInWorkingCapital,
                            StockBasedCompensation = kv.Value.StockBasedCompensation,
                            OtherNonCashItems = kv.Value.OtherNonCashItems,
                            FreeCashFlow = kv.Value.FreeCashFlow

                        }).ToList(),
                        YearlyCashFlow = companyData.Financials.CashFlow.Yearly?.Select(kv => new CashFlow
                        {
                            Date = SafeParseDateOnly(kv.Value.Date),
                            FilingDate = SafeParseDateOnly(kv.Value.FilingDate),
                            CurrencyCode = kv.Value.CurrencySymbol,
                            Investments = kv.Value.Investments,
                            TotalCashFromFinancingActivities = kv.Value.TotalCashFromFinancingActivities,
                            NetIncome = kv.Value.NetIncome,
                            ChangeInCash = kv.Value.ChangeInCash,
                            Depreciation = kv.Value.Depreciation,
                            DividendsPaCode = kv.Value.DividendsPaCode,
                            ChangeToInventory = kv.Value.ChangeToInventory,
                            ChangeToAccountReceivables = kv.Value.ChangeToAccountReceivables,
                            SalePurchaseOfStock = kv.Value.SalePurchaseOfStock,
                            OtherCashflowsFromFinancingActivities = kv.Value.OtherCashflowsFromFinancingActivities,
                            CapitalExpenditures = kv.Value.CapitalExpenditures,
                            TotalCashFromOperatingActivities = kv.Value.TotalCashFromOperatingActivities,
                            ChangeReceivables = kv.Value.ChangeReceivables,
                            ChangeInWorkingCapital = kv.Value.ChangeInWorkingCapital,
                            StockBasedCompensation = kv.Value.StockBasedCompensation,
                            OtherNonCashItems = kv.Value.OtherNonCashItems,
                            FreeCashFlow = kv.Value.FreeCashFlow
                        }).ToList()

                    };
                }
            }

            newCompany.SetBalanceSheet(financials.BalanceSheet!);
            newCompany.SetIncomeStatement(financials.IncomeStatement!);
            newCompany.SetCashFlow(financials.CashFlow!);
            return newCompany;
        }

        private static readonly char[] separator = [','];

        public Exchange Map(string exchangeCode, ExchangeExternalDto exchangeData)
        {
            var exchange = Exchange.Create(
                exchangeCode, 
                exchangeData.Currency!,
                exchangeData.Name!,
                exchangeData.OperatingMIC!,
                exchangeData.Country!,
                exchangeData.TimeZone!);

            if (exchangeData.TradingHours != null)
            {

                exchange.UpdateTradingHours(new TradingHours
                {
                    Open = TimeOnly.Parse(exchangeData.TradingHours.Open!),
                    Close = TimeOnly.Parse(exchangeData.TradingHours.Close!),
                    OpenUtc = TimeOnly.Parse(exchangeData.TradingHours.OpenUtc!),
                    CloseUtc = TimeOnly.Parse(exchangeData.TradingHours.CloseUtc!),
                    WorkingDays = exchangeData.TradingHours.WorkingDays?.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList() ?? []
                });
            }

            if (exchangeData.ExchangeHolidays != null)
            {
                foreach (var h in exchangeData.ExchangeHolidays.Values)
                {
                    exchange.AddHoliday(new Holiday
                    {
                        Name = h.Holiday,
                        Date = SafeParseDateOnly(h.Date),
                        Type = h.Type
                    });
                }
            }

            if (exchangeData.ExchangeEarlyCloseDays != null)
            {
                foreach (var e in exchangeData.ExchangeEarlyCloseDays.Values)
                {
                    exchange.AddHoliday(new EarlyCloseDay
                    {
                        Name = e.Holiday,
                        Date = SafeParseDateOnly(e.Date),
                        Type = e.Type,
                        CloseTime = TimeOnly.Parse(e.EarlyClose!)
                    });
                }
            }

            return exchange;
        }

        public Price Map(string securityCode,PriceExternalDto priceData)
        {
            var price = Price.Create(
                securityCode,
                (DateOnly)SafeParseDateOnly(priceData.Date)!,
                (decimal)priceData.Open!,
                (decimal)priceData.High!,
                (decimal)priceData.Low!,
                (decimal)priceData.Close!,
                (long)priceData.Volume!,
                (decimal)priceData.AdjustedClose!
            );
            return price;
        }
    }
}
