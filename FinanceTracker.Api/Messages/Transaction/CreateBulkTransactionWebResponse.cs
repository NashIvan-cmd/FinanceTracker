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
    /// Represents the web response returned after successfully creating transactions in bulk.
    /// </summary>
    public class CreateBulkTransactionWebResponse : WebResponse<CreateBulkTransactionResult>
    {
        public CreateBulkTransactionWebResponse(CreateBulkTransactionResult data, string errorCode = "", string message = "")
            : base(data, errorCode, message)
        {
        }

        [JsonIgnore]
        public override HttpStatusCode SuccessCode => HttpStatusCode.Created;

        [JsonIgnore]
        public override Dictionary<string, HttpStatusCode> ErrorCodes => new()
        {
            { Infrastructure.Constants.Errors.ErrorCodes.Default, HttpStatusCode.BadRequest },
            { TransactionServiceErrorCodes.ValidationError, HttpStatusCode.BadRequest },
            { TransactionServiceErrorCodes.UnexpectedError, HttpStatusCode.InternalServerError },
        };
    }
}
