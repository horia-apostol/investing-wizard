using InvestingWizard.Shared.Common;

namespace InvestingWizard.Domain.Portfolios
{
    public sealed class PortfolioEntry : AuditableEntity
    {
        public Guid Id { get; private set; }
        public string SecurityCode { get; private set; }
        public decimal TotalUnits { get; private set; }
        public decimal AverageUnitPrice { get; private set; }
        public string CurrencyCode { get; private set; }

        private PortfolioEntry(string securityCode, decimal totalUnits, decimal averageUnitPrice, string currencyCode)
        {
            Id = Guid.NewGuid();
            SecurityCode = securityCode;
            TotalUnits = totalUnits;
            AverageUnitPrice = averageUnitPrice;
            CurrencyCode = currencyCode;

        }

        public static PortfolioEntry Create(string securityCode, decimal totalUnits, decimal averageUnitPrice, string currencyCode)
        {
            return new PortfolioEntry(securityCode, totalUnits, averageUnitPrice, currencyCode);
        }

        public void UpdateTotalUnitsAndAveragePrice(decimal units, decimal unitPrice)
        {
            var newTotalUnits = TotalUnits + units;
            if (newTotalUnits == 0)
            {
                TotalUnits = 0;
                AverageUnitPrice = 0;
                return;
            }
            var newAverageUnitPrice = ((TotalUnits * AverageUnitPrice) + (units * unitPrice)) / newTotalUnits;
            TotalUnits = newTotalUnits;
            AverageUnitPrice = newAverageUnitPrice;
        }

        public decimal CalculateProfitLoss(decimal currentPrice)
        {
            return (((currentPrice - AverageUnitPrice) * TotalUnits) / (AverageUnitPrice * TotalUnits)) * 100;
        }

        public decimal CalculateTotalValue(decimal currentPrice)
        {
            return TotalUnits * currentPrice;
        }
    }
}
