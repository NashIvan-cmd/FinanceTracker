using System;

namespace FinanceTracker.Infrastructure.Messages.Budget;

public class ApplyDefaultBudgetDistributionRequest
{
    public Guid UserId { get; set; }

    public Guid GroupId { get; set; }

    public double TotalBudgetAmount { get; set; }
}
