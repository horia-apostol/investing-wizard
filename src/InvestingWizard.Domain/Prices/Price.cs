using InvestingWizard.Shared.Common;

namespace InvestingWizard.Domain.Prices
{
    public class Price : AuditableEntity
    {
        public Guid Id { get; private set; }
        public string SecurityCode { get; private set; } 
        public DateOnly Date { get; private set; }
        public decimal Open { get; private set; }
        public decimal High { get; private set; }
        public decimal Low { get; private set; }
        public decimal Close { get; private set; }
        public long Volume { get; private set; }
        public decimal AdjustedClose { get; private set; }

        private Price(string securityCode, DateOnly date, decimal open, decimal high, decimal low, decimal close, long volume, decimal adjustedClose)
        {
            Id = Guid.NewGuid();
            SecurityCode = securityCode;
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            AdjustedClose = adjustedClose;
        }

        public static Price Create(string securityCode, DateOnly date, decimal open, decimal high, decimal low, decimal close, long volume, decimal adjustedClose)
        {
            return new Price(securityCode, date, open, high, low, close, volume, adjustedClose);
        }

        public void UpdateOpen(decimal open) => Open = open;
        public void UpdateHigh(decimal high) => High = high;
        public void UpdateLow(decimal low) => Low = low;
        public void UpdateClose(decimal close) => Close = close;
        public void UpdateVolume(long volume) => Volume = volume;
        public void UpdateAdjustedClose(decimal adjustedClose) => AdjustedClose = adjustedClose;
    }
}
