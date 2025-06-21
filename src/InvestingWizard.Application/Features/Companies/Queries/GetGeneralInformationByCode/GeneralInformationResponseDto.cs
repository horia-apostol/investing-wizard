namespace InvestingWizard.Application.Features.Companies.Queries.GetGeneralInformationByCode
{
    public class GeneralInformationResponseDto
    {
        public string? Type { get; set; }
        public string? CurrencyCode { get; set; }
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
        public DateOnly? IPODate { get; set; }
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
        public string? HeadquartersCountry { get; set; }
        public string? Phone { get; set; }
        public string? WebURL { get; set; }
        public string? LogoURL { get; set; }
        public string? CeoName { get; set; }
        public int? FullTimeEmployees { get; set; }
    }
}