using System;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Messages.Transaction;

public class CreateBulkTransactionRequest
{
    public List<CreateTransactionRequest> Transactions { get; set; } = new();
}
