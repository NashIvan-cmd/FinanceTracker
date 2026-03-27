using System;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Messages.Budget;

public class ApplyDefaultBudgetDistributionResult
{
    public List<CreateBudgetResult> CreatedBudgets { get; set; } = new();

    public int BudgetsCreated { get; set; }
}
