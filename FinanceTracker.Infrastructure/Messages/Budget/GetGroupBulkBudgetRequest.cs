using System;

namespace FinanceTracker.Infrastructure.Messages.Budget;

public class GetGroupBulkBudgetRequest
{
    public Guid GroupId { get; set; }
}
