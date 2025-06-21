using InvestingWizard.Shared.Common;

namespace InvestingWizard.Domain.Portfolios
{
    public sealed class Transaction : AuditableEntity
    {
        public Guid Id { get; private set; }
        public DateOnly Date { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Units { get; private set; }
        public decimal Amount { get; private set; }
        public decimal AmountInUserCurrency { get; private set; }
        public string TransactionCurrencyCode { get; private set; }
        public string UserCurrencyCode { get; private set; }
        public string SecurityCode { get; private set; }
        public bool BrokerIsResident { get; private set; }

        private Transaction(DateOnly date, decimal unitPrice, decimal units, string transactionCurrencyCode, string userCurrencyCode, string securityCode, decimal amountInUserCurrency, bool brokerIsResident)
        {
            Id = Guid.NewGuid();
            Date = date;
            UnitPrice = unitPrice;
            Units = units;
            Amount = unitPrice * units;
            TransactionCurrencyCode = transactionCurrencyCode;
            UserCurrencyCode = userCurrencyCode;
            SecurityCode = securityCode;
            AmountInUserCurrency = amountInUserCurrency;
            BrokerIsResident = brokerIsResident;
        }

        public static Transaction Create(DateOnly date, decimal unitPrice, decimal units, string transactionCurrencyCode, string userCurrencyCode, string securityCode, decimal amountInUserCurrency, bool brokerIsResident)
        {
            return new Transaction(date, unitPrice, units, transactionCurrencyCode, userCurrencyCode, securityCode, amountInUserCurrency, brokerIsResident);
        }

        public void UpdateTransaction(decimal unitPrice, decimal units, decimal amountInUserCurrency)
        {
            UnitPrice = unitPrice;
            Units = units;
            AmountInUserCurrency = amountInUserCurrency;
            Amount = unitPrice * units;
        }
    }
}
