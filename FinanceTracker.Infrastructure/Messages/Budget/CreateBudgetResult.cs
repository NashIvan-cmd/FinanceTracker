using System;

namespace FinanceTracker.Infrastructure.Messages.Budget;

public class CreateBudgetResult
{
    public Guid Id { get; set; }

    public double ActualBudget { get; set; }

    public double TargetSavings { get; set; }

    public string TargetItem { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }

    public int AlertThreshold { get; set; } = 80;

    public Guid GroupId { get; set; }
}
