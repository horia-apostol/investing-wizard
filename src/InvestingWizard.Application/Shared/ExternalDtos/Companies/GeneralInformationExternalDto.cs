namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class GeneralInformationExternalDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? CurrencyCode { get; set; }
        public string? CurrencyName { get; set; }
        public string? CurrencySymbol { get; set; }
        public string? CountryName { get; set; }
        public string? CountryISO { get; set; }
        public string? OpenFigi { get; set; }
        public string? ISIN { get; set; }
        public string? LEI { get; set; }
        public string? PrimaryTicker { get; set; }
        public string? CUSIP { get; set; }
        public string? CIK { get; set; }
        public string? EmployerCodeNumber { get; set; }
        public string? FiscalYearEnd { get; set; }
        public string? IPODate { get; set; }
        public string? InternationalDomestic { get; set; }
        public string? Sector { get; set; }
        public string? Industry { get; set; }
        public string? GicSector { get; set; }
        public string? GicGroup { get; set; }
        public string? GicIndustry { get; set; }
        public string? GicSubIndustry { get; set; }
        public string? HomeCategory { get; set; }
        public bool? IsDelisted { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? WebURL { get; set; }
        public string? LogoURL { get; set; }
        public AddressExternalDto? AddressData { get; set; }
        public Dictionary<string, OfficerExternalDto>? Officers { get; set; }
        public int? FullTimeEmployees { get; set; }
    }
}