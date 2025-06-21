using InvestingWizard.Shared.Common;

namespace InvestingWizard.Domain.Companies
{
    public class Company : AuditableEntity
    {
        public string Code { get; private set; }
        public string ExchangeCode { get; private set; } 
        public string? Name { get; private set; }
        public string? Ticker { get; private set; }
        public GeneralInformation? GeneralInformation { get; private set; }
        public Highlights? Highlights { get; private set; }
        public Valuation? Valuation { get; private set; }
        public SharesStats? SharesStats { get; private set; }
        public Technicals? Technicals { get; private set; }
        public SplitsDividends? SplitsDividends { get; private set; }
        public AnalystRatings? AnalystRatings { get; private set; }
        public Holders? Holders { get; private set; }
        public InsiderTransactions? InsiderTransactions { get; private set; }
        public EsgScores? EsgScores { get; private set; }
        public OutstandingShares? OutstandingShares { get; private set; }
        public Earnings? Earnings { get; private set; }
        public Financials? Financials { get; private set; }

        private Company(string code, string exchangeCode)
        {
            Code = code;
            ExchangeCode = exchangeCode;
            Financials = new Financials();
        }
        public static Company Create(string code, string exchangeCode)
        {
            return new Company(code, exchangeCode);
        }

        public void SetName(string name) => Name = name;
        public void SetTicker(string ticker) => Ticker = ticker;
        public void SetGeneralInformation(GeneralInformation generalInformation) => GeneralInformation = generalInformation;
        public void SetHighlights(Highlights highlights) => Highlights = highlights;
        public void SetValuation(Valuation valuation) => Valuation = valuation;
        public void SetSharesStats(SharesStats sharesStats) => SharesStats = sharesStats;
        public void SetTechnicals(Technicals technicals) => Technicals = technicals;
        public void SetSplitsDividends(SplitsDividends splitsDividends) => SplitsDividends = splitsDividends;
        public void SetAnalystRatings(AnalystRatings analystRatings) => AnalystRatings = analystRatings;
        public void SetHolders(Holders holders) => Holders = holders;
        public void SetInsiderTransactions(InsiderTransactions insiderTransactions) => InsiderTransactions = insiderTransactions;
        public void SetEsgScores(EsgScores esgScores) => EsgScores = esgScores;
        public void SetOutstandingShares(OutstandingShares outstandingShares) => OutstandingShares = outstandingShares;
        public void SetEarnings(Earnings earnings) => Earnings = earnings;
        public void SetBalanceSheet(BalanceSheetReport balanceSheet) => Financials!.BalanceSheet = balanceSheet;
        public void SetCashFlow(CashFlowReport cashFlow) => Financials!.CashFlow = cashFlow;
        public void SetIncomeStatement(IncomeStatementReport incomeStatement) => Financials!.IncomeStatement = incomeStatement;
    }
}
