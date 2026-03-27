using System;

namespace FinanceTracker.Api.Messages.Budget;

public class GetBudgetWebRequest
{
    public Guid BudgetId { get; set; }
}
