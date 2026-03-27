using System;
using System.Collections.Generic;

namespace FinanceTracker.Api.Messages.Budget;

public class CreateDefaultBudgetDistributionWebRequest
{
    public Guid UserId { get; set; }

    public Guid? GroupId { get; set; }

    public List<BudgetCategoryDistributionWebRequest> Distributions { get; set; } = new();
}

public class BudgetCategoryDistributionWebRequest
{
    public string Category { get; set; } = string.Empty;

    public double Amount { get; set; }

    public int Priority { get; set; } = 0;
}
