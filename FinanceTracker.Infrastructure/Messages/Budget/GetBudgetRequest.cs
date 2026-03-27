using System;

namespace FinanceTracker.Infrastructure.Messages.Budget;

public class GetBudgetRequest
{
    public Guid BudgetId { get; set; }
}
