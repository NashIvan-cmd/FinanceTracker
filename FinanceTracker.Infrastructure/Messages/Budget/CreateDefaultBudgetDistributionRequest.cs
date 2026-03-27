using System;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Messages.Budget;

public class CreateDefaultBudgetDistributionRequest
{
    public Guid UserId { get; set; }

    public Guid? GroupId { get; set; }

    public List<BudgetCategoryDistribution> Distributions { get; set; } = new();
}

public class BudgetCategoryDistribution
{
    public string Category { get; set; } = string.Empty;

    public double Amount { get; set; }

    public int Priority { get; set; } = 0;
}
