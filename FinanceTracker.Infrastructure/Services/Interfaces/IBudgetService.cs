namespace FinanceTracker.Infrastructure.Services.Interfaces
{
    using System.Dynamic;
    using System.Threading.Tasks;
    using FinanceTracker.Infrastructure.Messages;
    using FinanceTracker.Infrastructure.Messages.Budget;

    public interface IBudgetService
    {
        Task<Response<CreateBulkBudgetResult>> CreateBulkBudgetAsync(CreateBulkBudgetRequest request);

        Task<Response<GetBudgetResponse>> GetBudgetAsync(GetBudgetRequest request);

        Task<Response<GetGroupBulkBudgetResponse>> GetGroupBudgetsAsync(GetGroupBulkBudgetRequest request);

        Task<Response<GetPersonalBudgetsResponse>> GetPersonalBudgetsAsync(GetPersonalBudgetsRequest request);

        Task<Response<CreateDefaultBudgetDistributionResult>> CreateDefaultBudgetDistributionAsync(CreateDefaultBudgetDistributionRequest request);

        Task<Response<ApplyDefaultBudgetDistributionResult>> ApplyDefaultBudgetDistributionAsync(ApplyDefaultBudgetDistributionRequest request);
    } 
}


