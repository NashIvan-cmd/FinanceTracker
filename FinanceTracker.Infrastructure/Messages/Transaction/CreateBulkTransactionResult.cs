using System;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Messages.Transaction;

public class CreateBulkTransactionResult
{
    public List<CreateTransactionResult> Transactions { get; set; } = new();

    public int SuccessCount { get; set; }

    public int FailureCount { get; set; }
}
