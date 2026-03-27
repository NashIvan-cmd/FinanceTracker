using System;

namespace FinanceTracker.Infrastructure.Messages.Budget;

public class GetPersonalBudgetsRequest
{
    public Guid UserId { get; set; }
}
