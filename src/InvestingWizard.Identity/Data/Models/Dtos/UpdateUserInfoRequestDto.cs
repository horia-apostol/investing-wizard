namespace InvestingWizard.Identity.Data.Models.Dtos
{
    public sealed class UpdateUserInfoRequestDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? TaxIdentificationNumber { get; set; }
        public string? PreferredCurrencyCode { get; set; }
    }
}