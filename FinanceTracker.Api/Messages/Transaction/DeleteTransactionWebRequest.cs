using System;

namespace FinanceTracker.Api.Messages.Transaction;

public class DeleteTransactionWebRequest
{
    public Guid TransactionId { get; set; }
}
