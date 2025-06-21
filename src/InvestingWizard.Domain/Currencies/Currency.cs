using InvestingWizard.Shared.Common;

namespace InvestingWizard.Domain.Currencies
{
    public sealed class Currency : AuditableEntity
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Symbol { get; private set; }

        private Currency(string code, string name, string symbol)
        {
            Code = code;
            Name = name;
            Symbol = symbol;
        }

        public static Currency Create(string code, string name, string symbol)
        {
            return new Currency(code, name, symbol);
        }

        public void UpdateName(string name) => Name = name;
        public void UpdateSymbol(string symbol) => Symbol = symbol;
    }
}
