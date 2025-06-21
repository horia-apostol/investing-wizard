using Microsoft.AspNetCore.Identity;

namespace InvestingWizard.Identity.Data.Models
{
    public sealed class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string PreferredCurrencyCode { get; private set; } = "RON";
        public void SetFirstName(string firstName) => FirstName = firstName;
        public void SetLastName(string lastName) => LastName = lastName;
        public void SetPreferredCurrencyCode(string preferredCurrencyCode) => PreferredCurrencyCode = preferredCurrencyCode;
    }
}