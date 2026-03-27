using System;

namespace FinanceTracker.Api.Messages.Budget;

public class ApplyDefaultBudgetDistributionWebRequest
{
    public Guid UserId { get; set; }

    public Guid GroupId { get; set; }

    public double TotalBudgetAmount { get; set; }
}
