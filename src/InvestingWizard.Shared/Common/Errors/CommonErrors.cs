namespace InvestingWizard.Shared.Common.Errors
{
    public static class CommonErrors
    {
        public static readonly Error UnexpectedNullValue = new("UnexpectedNullValue", "Value is null.");
        public static readonly Error EntityNotFound = new("EntityNotFound", "Entity not found.");
        public static readonly Error DatabaseUpdateError = new("DatabaseUpdateError", "An error occurred while updating the database.");
        public static readonly Error ConcurrencyConflict = new("ConcurrencyConflict", "A concurrency conflict occurred.");
        public static readonly Error UnexpectedError = new("UnexpectedError", "An unexpected error occurred.");
        public static readonly Error NoEntitiesFound = new("NoEntitiesFound", "No entities were found.");
        public static readonly Error EntityAlreadyExists = new("EntityAlreadyExists", "Entity already exists.");
        public static readonly Error UnauthorizedAccess = new("UnauthorizedAccess", "Unauthorized access.");
    }
}