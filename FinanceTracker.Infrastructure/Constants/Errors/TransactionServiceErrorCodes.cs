namespace FinanceTracker.Infrastructure.Constants.Errors
{
    public static class TransactionServiceErrorCodes
    {
        public const string ValidationError = "transaction/validation-error";

        public const string UnexpectedError = "transaction/unexpected-error";

        public const string TransactionNotFound = "transaction/not-found";

        public const string GroupNotFound = "transaction/group-not-found";

        public const string UserNotFound = "transaction/user-not-found";

        public const string InvalidAmount = "transaction/invalid-amount";

        public const string InvalidType = "transaction/invalid-type";

        public const string Unauthorized = "transaction/unauthorized";

        public const string FailedToDelete = "transaction/failed-to-delete";

        public const string FailedToUpdate = "transaction/failed-to-update";
    }
}
