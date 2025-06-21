namespace InvestingWizard.Shared.Common.Errors
{
    public sealed record CustomError(string Code, string? Description = null)
        : Error(Code, Description);
}