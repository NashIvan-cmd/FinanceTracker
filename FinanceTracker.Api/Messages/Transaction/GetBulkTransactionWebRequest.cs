using System;

namespace FinanceTracker.Api.Messages.Transaction;

public class GetBulkTransactionWebRequest
{
    public Guid TransactionId { get; set; }
}
