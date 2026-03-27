using System;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Messages.Budget;

public class CreateDefaultBudgetDistributionResult
{
    public Guid UserId { get; set; }

    public Guid? GroupId { get; set; }

    public List<BudgetCategoryDistribution> Distributions { get; set; } = new();

    public bool Success { get; set; }
}
