using System;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Messages.Budget;

public class CreateBulkBudgetResult
{
    public List<CreateBudgetResult> Budgets { get; set; } = new();

    public int SuccessCount { get; set; }

    public int FailureCount { get; set; }
}
