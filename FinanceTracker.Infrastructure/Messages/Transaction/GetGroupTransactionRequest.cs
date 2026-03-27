using System;

namespace FinanceTracker.Infrastructure.Messages.Transaction;

public class GetGroupTransactionRequest
{
    public Guid GroupId { get; set; }
}
