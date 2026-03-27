using System;

namespace FinanceTracker.Infrastructure.Messages.Transaction;

public class GetTransactionRequest
{
    public Guid TransactionId { get; set; }
}
