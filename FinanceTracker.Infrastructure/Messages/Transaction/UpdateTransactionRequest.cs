using System;

namespace FinanceTracker.Infrastructure.Messages.Transaction;

public class UpdateTransactionRequest
{
    public Guid TransactionId { get; set; }

    public bool? IsNecessity { get; set; }

    public double? Amount { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;
}
