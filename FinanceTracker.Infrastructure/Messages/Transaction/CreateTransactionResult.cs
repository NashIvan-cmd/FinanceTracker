using System;

namespace FinanceTracker.Infrastructure.Messages.Transaction;

public class CreateTransactionResult
{
    public Guid Id { get; set; }

    public bool IsNecessity { get; set; } = true;

    public double Amount { get; set; }

    public string Type { get; set; } = "expense";

    public string Description { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public Guid? Group { get; set; }
}
