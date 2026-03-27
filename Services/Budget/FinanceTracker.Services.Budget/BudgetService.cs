namespace FinanceTracker.Services.Budget;

using FinanceTracker.Infrastructure.Messages;
using FinanceTracker.Infrastructure.Messages.Budget;
using FinanceTracker.Infrastructure.Services.Interfaces;

public class BudgetService : IBudgetService
{

    public async Task<Response<CreateBulkBudgetResult>> CreateBulkBudgetAsync(CreateBulkBudgetRequest request)
    {
        var successResult = new Response<CreateBulkBudgetResult>(new CreateBulkBudgetResult
        {
        });

        return successResult;
    }

    public async Task<Response<GetBudgetResponse>> GetBudgetAsync(GetBudgetRequest request)
    {
        var successResponse = new Response<GetBudgetResponse>();

        return successResponse;
    }

    public async Task<Response<GetGroupBulkBudgetResponse>> GetGroupBudgetsAsync(GetGroupBulkBudgetRequest request)
    {
        var successResponse = new Response<GetGroupBulkBudgetResponse>();

        return successResponse;
    }

    public async Task<Response<GetPersonalBudgetsResponse>> GetPersonalBudgetsAsync(GetPersonalBudgetsRequest request)
    {
        var successResponse = new Response<GetPersonalBudgetsResponse>();

        return successResponse;
    }

    public async Task<Response<CreateDefaultBudgetDistributionResult>> CreateDefaultBudgetDistributionAsync(CreateDefaultBudgetDistributionRequest request)
    {
        var successResult = new Response<CreateDefaultBudgetDistributionResult>();

        return successResult;
    }

    public async Task<Response<ApplyDefaultBudgetDistributionResult>> ApplyDefaultBudgetDistributionAsync(ApplyDefaultBudgetDistributionRequest request)
    {
        var successResult = new Response<ApplyDefaultBudgetDistributionResult>();

        return successResult;
    }
}
