namespace FinanceTracker.Api.Messages.Budget
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text.Json.Serialization;
    using FinanceTracker.Api.Common.Responses;
    using FinanceTracker.Infrastructure.Constants.Errors;
    using FinanceTracker.Infrastructure.Messages.Budget;

    /// <summary>
    /// Represents the web response returned after successfully retrieving group budgets.
    /// </summary>
    public class GetGroupBudgetsWebResponse : WebResponse<GetGroupBulkBudgetResponse>
    {
        public GetGroupBudgetsWebResponse(GetGroupBulkBudgetResponse data, string errorCode = "", string message = "")
            : base(data, errorCode, message)
        {
        }

        [JsonIgnore]
        public override HttpStatusCode SuccessCode => HttpStatusCode.OK;

        [JsonIgnore]
        public override Dictionary<string, HttpStatusCode> ErrorCodes => new()
        {
            { Infrastructure.Constants.Errors.ErrorCodes.Default, HttpStatusCode.BadRequest },
            { BudgetServiceErrorCodes.GroupNotFound, HttpStatusCode.NotFound },
            { BudgetServiceErrorCodes.UnexpectedError, HttpStatusCode.InternalServerError },
        };
    }
}
