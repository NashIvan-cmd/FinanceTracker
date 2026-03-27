using System;
using System.Collections.Generic;
using System.Linq;
using FinanceTracker.Api.Messages.Budget;
using FinanceTracker.Infrastructure.Messages;
using FinanceTracker.Infrastructure.Messages.Budget;

namespace FinanceTracker.Api.Extensions.Models;

public static class BudgetWebExtension
{
    // Request mapping methods
    public static CreateBulkBudgetRequest ToCreateBulkBudgetRequest(this CreateBulkBudgetWebRequest webRequest)
    {
        return new CreateBulkBudgetRequest
        {
            Budgets = webRequest.Budgets.Select(b => new CreateBudgetRequest
            {
                ActualBudget = b.ActualBudget,
                TargetSavings = b.TargetSavings,
                TargetItem = b.TargetItem,
                Category = b.Category,
                Description = b.Description,
                DueDate = b.DueDate,
                AlertThreshold = b.AlertThreshold,
                GroupId = b.GroupId
            }).ToList()
        };
    }

    public static GetBudgetRequest ToGetBudgetRequest(this GetBudgetWebRequest webRequest)
    {
        return new GetBudgetRequest
        {
            BudgetId = webRequest.BudgetId
        };
    }

    public static GetGroupBulkBudgetRequest ToGetGroupBudgetsRequest(this GetGroupBudgetsWebRequest webRequest)
    {
        return new GetGroupBulkBudgetRequest
        {
            GroupId = webRequest.GroupId
        };
    }

    public static GetPersonalBudgetsRequest ToGetPersonalBudgetsRequest(this GetPersonalBudgetsWebRequest webRequest)
    {
        return new GetPersonalBudgetsRequest
        {
            UserId = webRequest.UserId
        };
    }

    public static CreateDefaultBudgetDistributionRequest ToCreateDefaultBudgetDistributionRequest(this CreateDefaultBudgetDistributionWebRequest webRequest)
    {
        return new CreateDefaultBudgetDistributionRequest
        {
            UserId = webRequest.UserId,
            GroupId = webRequest.GroupId,
            Distributions = webRequest.Distributions.Select(d => new BudgetCategoryDistribution
            {
                Category = d.Category,
                Amount = d.Amount,
                Priority = d.Priority
            }).ToList()
        };
    }

    public static ApplyDefaultBudgetDistributionRequest ToApplyDefaultBudgetDistributionRequest(this ApplyDefaultBudgetDistributionWebRequest webRequest)
    {
        return new ApplyDefaultBudgetDistributionRequest
        {
            UserId = webRequest.UserId,
            GroupId = webRequest.GroupId,
            TotalBudgetAmount = webRequest.TotalBudgetAmount
        };
    }

    // Response mapping methods
    public static CreateBulkBudgetWebResponse AsCreateBulkBudgetWebResponse(this Response<CreateBulkBudgetResult> response)
    {
        return new CreateBulkBudgetWebResponse(response.Data, response.ErrorCode, response.Message);
    }

    public static GetBudgetWebResponse AsGetBudgetWebResponse(this Response<GetBudgetResponse> response)
    {
        return new GetBudgetWebResponse(response.Data, response.ErrorCode, response.Message);
    }

    public static GetGroupBudgetsWebResponse AsGetGroupBudgetsWebResponse(this Response<GetGroupBulkBudgetResponse> response)
    {
        return new GetGroupBudgetsWebResponse(response.Data, response.ErrorCode, response.Message);
    }

    public static GetPersonalBudgetsWebResponse AsGetPersonalBudgetsWebResponse(this Response<GetPersonalBudgetsResponse> response)
    {
        return new GetPersonalBudgetsWebResponse(response.Data, response.ErrorCode, response.Message);
    }

    public static CreateDefaultBudgetDistributionWebResponse AsCreateDefaultBudgetDistributionWebResponse(this Response<CreateDefaultBudgetDistributionResult> response)
    {
        return new CreateDefaultBudgetDistributionWebResponse(response.Data, response.ErrorCode, response.Message);
    }

    public static ApplyDefaultBudgetDistributionWebResponse AsApplyDefaultBudgetDistributionWebResponse(this Response<ApplyDefaultBudgetDistributionResult> response)
    {
        return new ApplyDefaultBudgetDistributionWebResponse(response.Data, response.ErrorCode, response.Message);
    }
}
