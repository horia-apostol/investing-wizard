using InvestingWizard.Shared.Common;

namespace InvestingWizard.Domain.Portfolios
{
    public sealed class Portfolio : AuditableEntity
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public List<Transaction> Transactions { get; private set; }
        public List<PortfolioEntry> PortfolioEntries { get; private set; }

        private Portfolio(Guid userId, string name)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
            Transactions = [];
            PortfolioEntries = [];
        }

        public static Portfolio Create(Guid userId, string name)
        {
            return new Portfolio(userId, name);
        }

        public void UpdateName(string name) => Name = name;

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
            var entry = PortfolioEntries.FirstOrDefault(e => e.SecurityCode == transaction.SecurityCode);
            if (entry == null)
            {
                entry = PortfolioEntry.Create(transaction.SecurityCode, transaction.Units, transaction.UnitPrice, transaction.TransactionCurrencyCode);
                PortfolioEntries.Add(entry);
            }
            else
            {
                entry.UpdateTotalUnitsAndAveragePrice(transaction.Units, transaction.UnitPrice);
            }
        }

        public void RemoveTransaction(Transaction transaction)
        {
            Transactions.Remove(transaction);
            var entry = PortfolioEntries.FirstOrDefault(e => e.SecurityCode == transaction.SecurityCode);
            if (entry != null)
            {
                entry.UpdateTotalUnitsAndAveragePrice(-transaction.Units, transaction.UnitPrice);
                if (entry.TotalUnits == 0)
                {
                    PortfolioEntries.Remove(entry);
                }
            }
        }

        public void CloseTransactionPartially(Guid transactionId, decimal quantity)
        {
            var transaction = Transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction != null)
            {
                decimal exchangeRate = transaction.AmountInUserCurrency / (transaction.UnitPrice * transaction.Units);

                decimal remainingUnits = transaction.Units - quantity;
                decimal remainingAmountInUserCurrency = remainingUnits * transaction.UnitPrice * exchangeRate;

                transaction.UpdateTransaction(transaction.UnitPrice, remainingUnits, remainingAmountInUserCurrency);

                var entry = PortfolioEntries.FirstOrDefault(e => e.SecurityCode == transaction.SecurityCode);
                if (entry != null)
                {
                    entry.UpdateTotalUnitsAndAveragePrice(-quantity, transaction.UnitPrice);
                    if (entry.TotalUnits == 0)
                    {
                        PortfolioEntries.Remove(entry);
                    }
                }
            }
        }

    }
}
