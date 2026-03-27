namespace FinanceTracker.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using FinanceTracker.Api.Common.Extensions;
    using FinanceTracker.Api.Extensions.Models;
    using FinanceTracker.Api.Messages.Budget;
    using FinanceTracker.Infrastructure.Services.Interfaces;
    using FinanceTracker.Infrastructure.Messages.Budget;

    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/budget")]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpPost("create-bulk")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateBulkBudgetWebResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateBulkBudgetWebResponse))]
        public async Task<IActionResult> CreateBulkBudgetAsync([FromBody] CreateBulkBudgetWebRequest request)
        {
            var serviceRequest = request.ToCreateBulkBudgetRequest();
            var result = await this._budgetService.CreateBulkBudgetAsync(serviceRequest);
            return this.CreateResponse(result.AsCreateBulkBudgetWebResponse());
        }

        [HttpGet("{budgetId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBudgetWebResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GetBudgetWebResponse))]
        public async Task<IActionResult> GetBudgetAsync(Guid budgetId)
        {
            var request = new GetBudgetRequest { BudgetId = budgetId };
            var result = await _budgetService.GetBudgetAsync(request);
            return this.CreateResponse(result.AsGetBudgetWebResponse());
        }

        [HttpGet("group/{groupId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetGroupBudgetsWebResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GetGroupBudgetsWebResponse))]
        public async Task<IActionResult> GetGroupBudgetsAsync(Guid groupId)
        {
            var request = new GetGroupBulkBudgetRequest { GroupId = groupId };
            var result = await _budgetService.GetGroupBudgetsAsync(request);
            return this.CreateResponse(result.AsGetGroupBudgetsWebResponse());
        }

        [HttpGet("personal/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPersonalBudgetsWebResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GetPersonalBudgetsWebResponse))]
        public async Task<IActionResult> GetPersonalBudgetsAsync(Guid userId)
        {
            var request = new GetPersonalBudgetsRequest { UserId = userId };
            var result = await _budgetService.GetPersonalBudgetsAsync(request);
            return this.CreateResponse(result.AsGetPersonalBudgetsWebResponse());
        }

        [HttpPost("default-distribution/create")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateDefaultBudgetDistributionWebResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateDefaultBudgetDistributionWebResponse))]
        public async Task<IActionResult> CreateDefaultBudgetDistributionAsync([FromBody] CreateDefaultBudgetDistributionWebRequest request)
        {
            var serviceRequest = request.ToCreateDefaultBudgetDistributionRequest();
            var result = await _budgetService.CreateDefaultBudgetDistributionAsync(serviceRequest);
            return this.CreateResponse(result.AsCreateDefaultBudgetDistributionWebResponse());
        }

        [HttpPost("default-distribution/apply")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApplyDefaultBudgetDistributionWebResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApplyDefaultBudgetDistributionWebResponse))]
        public async Task<IActionResult> ApplyDefaultBudgetDistributionAsync([FromBody] ApplyDefaultBudgetDistributionWebRequest request)
        {
            var serviceRequest = request.ToApplyDefaultBudgetDistributionRequest();
            var result = await _budgetService.ApplyDefaultBudgetDistributionAsync(serviceRequest);
            return this.CreateResponse(result.AsApplyDefaultBudgetDistributionWebResponse());
        }
    }
}