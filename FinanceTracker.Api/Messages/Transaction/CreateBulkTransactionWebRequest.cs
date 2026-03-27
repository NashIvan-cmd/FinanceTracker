using System;
using System.Collections.Generic;

namespace FinanceTracker.Api.Messages.Transaction;

public class CreateBulkTransactionWebRequest
{
    public List<CreateTransactionWebRequest> Transactions { get; set; } = new();
}

public class CreateTransactionWebRequest
{
    public bool IsNecessity { get; set; } = true;

    public double Amount { get; set; }

    public string Type { get; set; } = "expense";

    public string Description { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public Guid? Group { get; set; }
}
