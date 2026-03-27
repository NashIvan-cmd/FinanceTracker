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
    /// Represents the web response returned after successfully retrieving transactions in bulk.
    /// </summary>
    public class GetBulkTransactionWebResponse : WebResponse<GetBulkTransactionResponse>
    {
        public GetBulkTransactionWebResponse(GetBulkTransactionResponse data, string errorCode = "", string message = "")
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
            { TransactionServiceErrorCodes.UnexpectedError, HttpStatusCode.InternalServerError },
        };
    }
}
