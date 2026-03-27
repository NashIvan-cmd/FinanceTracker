using System;

namespace FinanceTracker.Api.Messages.Budget;

public class CreateBulkBudgetWebRequest
{
    public System.Collections.Generic.List<CreateBudgetWebRequest> Budgets { get; set; } = new();
}

public class CreateBudgetWebRequest
{
    public double ActualBudget { get; set; }

    public double TargetSavings { get; set; }

    public string TargetItem { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }

    public int AlertThreshold { get; set; } = 80;

    public Guid? GroupId { get; set; }
}
