namespace FinanceTracker.Api.Messages.Transaction
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text.Json.Serialization;
    using FinanceTracker.Api.Common.Responses;
    using FinanceTracker.Infrastructure.Constants.Errors;
    using FinanceTracker.Infrastructure.Messages.Transaction;

    /// <summary>
    /// Represents the web response returned after successfully deleting a transaction.
    /// </summary>
    public class DeleteTransactionWebResponse : WebResponse<DeleteTransactionResponse>
    {
        public DeleteTransactionWebResponse(DeleteTransactionResponse data, string errorCode = "", string message = "")
            : base(data, errorCode, message)
        {
        }

        [JsonIgnore]
        public override HttpStatusCode SuccessCode => HttpStatusCode.OK;

        [JsonIgnore]
        public override Dictionary<string, HttpStatusCode> ErrorCodes => new()
        {
            { Infrastructure.Constants.Errors.ErrorCodes.Default, HttpStatusCode.BadRequest },
            { TransactionServiceErrorCodes.TransactionNotFound, HttpStatusCode.NotFound },
            { TransactionServiceErrorCodes.FailedToDelete, HttpStatusCode.InternalServerError },
            { TransactionServiceErrorCodes.UnexpectedError, HttpStatusCode.InternalServerError },
        };
    }
}
