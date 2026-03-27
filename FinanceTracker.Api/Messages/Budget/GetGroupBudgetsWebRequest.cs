using System;

namespace FinanceTracker.Api.Messages.Budget;

public class GetGroupBudgetsWebRequest
{
    public Guid GroupId { get; set; }
}
