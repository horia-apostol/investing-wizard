using InvestingWizard.Shared.Common;

namespace InvestingWizard.Domain.Watchlists
{
    public sealed class Watchlist : AuditableEntity
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public List<string> SecurityCodes { get; private set; }
        public static Watchlist Create(Guid userId, string name)
        {
            return new Watchlist(userId, name);
        }
        public void UpdateId(Guid id) => Id = id;
        public void UpdateName(string name) => Name = name;
        public void AddSecurityCode(string securityCode)
            => SecurityCodes.Add(securityCode);
        public void RemoveSecurityCode(string securityCode) 
            => SecurityCodes.Remove(securityCode);
        private Watchlist(Guid userId, string name)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
            SecurityCodes = [];
        }
    }
}
