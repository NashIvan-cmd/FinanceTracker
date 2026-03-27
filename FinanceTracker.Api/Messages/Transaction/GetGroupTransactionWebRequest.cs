using System;

namespace FinanceTracker.Api.Messages.Transaction;

public class GetGroupTransactionWebRequest
{
    public Guid GroupId { get; set; }
}
