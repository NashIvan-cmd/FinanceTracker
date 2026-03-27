using System;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Messages.Budget;

public class GetPersonalBudgetsResponse
{
    public List<GetBudgetResponse> Budgets { get; set; } = new();
}
