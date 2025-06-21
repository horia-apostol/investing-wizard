namespace InvestingWizard.TradingAssistant.Models
{
    public class TransactionModel
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Units { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountInUserCurrency { get; set; }
        public string TransactionCurrencyCode { get; set; }
        public string UserCurrencyCode { get; set; }
        public string SecurityCode { get; set; }
        public bool BrokerIsResident { get; set; }
    }
}
