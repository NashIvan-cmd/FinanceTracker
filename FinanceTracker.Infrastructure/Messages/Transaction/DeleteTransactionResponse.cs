using System;

namespace FinanceTracker.Infrastructure.Messages.Transaction;

public class DeleteTransactionResponse
{
    public Guid TransactionId { get; set; }

    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;
}
