namespace FinanceTracker.Infrastructure.Constants.Errors
{
    public static class BudgetServiceErrorCodes
    {
        public const string ValidationError = "budget/validation-error";

        public const string UnexpectedError = "budget/unexpected-error";

        public const string BudgetNotFound = "budget/not-found";

        public const string GroupNotFound = "budget/group-not-found";

        public const string UserNotFound = "budget/user-not-found";

        public const string BudgetAlreadyExists = "budget/already-exists";

        public const string InsufficientFunds = "budget/insufficient-funds";

        public const string Unauthorized = "budget/unauthorized";

        public const string InvalidDistribution = "budget/invalid-distribution";

        public const string DefaultDistributionNotFound = "budget/default-distribution-not-found";
    }
}
