using InvestingWizard.Shared.Common;

namespace InvestingWizard.Domain.Exchanges
{
    public sealed class Exchange : AuditableEntity
    {
        public string Code { get; private set; }
        public string CurrencyCode { get; private set; }
        public string Name { get; private set; }
        public string OperatingMIC { get; private set; }
        public string Country { get; private set; }
        public string TimeZone { get; private set; }
        public List<Holiday> Holidays { get; private set; }
        public TradingHours TradingHours { get; private set; }

        private Exchange(string code, string currencyCode, string name, string operatingMIC, string country, string timeZone)
        {
            Code = code;
            CurrencyCode = currencyCode;
            Name = name;
            OperatingMIC = operatingMIC;
            Country = country;
            TimeZone = timeZone;
            Holidays = [];
            TradingHours = new TradingHours();
        }

        public static Exchange Create(string code, string currencyCode, string name, string operatingMIC, string country, string timeZone)
        {
            return new Exchange(code, currencyCode, name, operatingMIC, country, timeZone);
        }

        public void UpdateCurrencyCode(string currencyCode) => CurrencyCode = currencyCode;
        public void UpdateName(string name) => Name = name;
        public void UpdateOperatingMIC(string operatingMIC) => OperatingMIC = operatingMIC;
        public void UpdateCountry(string country) => Country = country;
        public void UpdateTimeZone(string timeZone) => TimeZone = timeZone;
        public void AddHoliday(Holiday holiday) => Holidays.Add(holiday);
        public void RemoveHoliday(Holiday holiday) => Holidays.Remove(holiday);
        public void UpdateTradingHours(TradingHours tradingHours) => TradingHours = tradingHours;

        public bool IsOpen(DateTime now)
        {
            if (!TradingHours.WorkingDays.Contains(now.DayOfWeek.ToString()[..3]))
                return false;

            if (Holidays.Any(h => h.Date == DateOnly.FromDateTime(now.Date)))
                return false;

            var openTime = TradingHours.Open?.ToTimeSpan();
            var closeTime = TradingHours.Close?.ToTimeSpan();

            if (openTime == null || closeTime == null)
                return false;

            return now.TimeOfDay >= openTime && now.TimeOfDay <= closeTime;
        }

        public bool WasOpenToday(DateTime now)
        {
            if (!TradingHours.WorkingDays.Contains(now.DayOfWeek.ToString()[..3]))
                return false;

            if (Holidays.Any(h => h.Date == DateOnly.FromDateTime(now.Date)))
                return false;

            var openTime = TradingHours.Open?.ToTimeSpan();
            return openTime != null && now.TimeOfDay > openTime;
        }

        public TimeSpan GetTimeUntilNextOpen(DateTime now)
        {
            var openTime = TradingHours.Open?.ToTimeSpan();
            var closeTime = TradingHours.Close?.ToTimeSpan();

            if (openTime == null || closeTime == null)
                return TimeSpan.Zero;

            DateTime nextOpen = now.Date.Add(openTime.Value);

            if (now.TimeOfDay > closeTime || !IsWorkingDay(now))
            {
                nextOpen = nextOpen.AddDays(1);
                while (!IsWorkingDay(nextOpen))
                {
                    nextOpen = nextOpen.AddDays(1);
                }
            }
            else if (now.TimeOfDay < openTime)
            {
                if (!IsWorkingDay(nextOpen))
                {
                    nextOpen = nextOpen.AddDays(1);
                    while (!IsWorkingDay(nextOpen))
                    {
                        nextOpen = nextOpen.AddDays(1);
                    }
                }
            }

            return nextOpen - now;
        }

        private bool IsWorkingDay(DateTime date)
        {
            var dayOfWeekShort = date.DayOfWeek.ToString().Substring(0, 3);
            if (!TradingHours.WorkingDays.Contains(dayOfWeekShort))
                return false;

            if (Holidays.Any(h => h.Date == DateOnly.FromDateTime(date.Date)))
                return false;

            return true;
        }
    }
}
