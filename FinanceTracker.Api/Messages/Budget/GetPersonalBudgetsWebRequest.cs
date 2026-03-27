using System;

namespace FinanceTracker.Api.Messages.Budget;

public class GetPersonalBudgetsWebRequest
{
    public Guid UserId { get; set; }
}
