using System;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Messages.Transaction;

public class GetBulkTransactionResponse
{
    public List<GetTransactionResponse> Transactions { get; set; } = new();
}
