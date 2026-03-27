using System;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Messages.Budget;

public class CreateBulkBudgetRequest
{
    public List<CreateBudgetRequest> Budgets { get; set; } = new();
}
