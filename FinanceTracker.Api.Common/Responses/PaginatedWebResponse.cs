namespace FinanceTracker.Api.Common.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using FinanceTracker.Infrastructure.Models;

    public class PaginatedWebResponse<T> : WebResponse
    {
        public PaginatedWebResponse(IEnumerable<T> data, PaginationMetadata pagination, string errorCode = "", string message = "")
            : base(errorCode, message)
        {
            this.Data = data;
            this.Pagination = pagination;
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<T> Data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PaginationMetadata Pagination { get; set; }
    }
}