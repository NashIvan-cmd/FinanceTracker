using System;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Messages.Transaction;

public class GetGroupTransactionResponse
{
    public List<GetTransactionResponse> Transactions { get; set; } = new();
}
