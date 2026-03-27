using System;

namespace FinanceTracker.Infrastructure.Messages.Transaction;

public class DeleteTransactionRequest
{
    public Guid TransactionId { get; set; }
}
