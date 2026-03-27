using FinanceTracker.Api.Common.Extensions;
using FinanceTracker.Api.Extensions.Models;
using FinanceTracker.Api.Messages.Transaction;
using FinanceTracker.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FinanceTracker.Controllers
{
    [Route("api/transaction")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateBulkTransactionWebResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateBulkTransactionWebResponse))]
        public async Task<IActionResult> CreateBulkTransactionAsync(CreateBulkTransactionWebRequest request)
        {
            var serviceRequest = request.ToCreateBulkTransactionRequest();
            var result = await _transactionService.CreateBulkTransactionAsync(serviceRequest);
            return this.CreateResponse(result.AsCreateBulkTransactionWebResponse());
        }

        [HttpGet("{transactionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBulkTransactionWebResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GetBulkTransactionWebResponse))]
        public async Task<IActionResult> GetBulkTransactionAsync(GetBulkTransactionWebRequest request)
        {
            var serviceRequest = request.ToGetTransactionRequest();
            var result = await _transactionService.GetBulkTransactionAsync(serviceRequest);
            return this.CreateResponse(result.AsGetBulkTransactionWebResponse());
        }

        [HttpGet("group/{groupId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetGroupTransactionWebResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GetGroupTransactionWebResponse))]
        public async Task<IActionResult> GetGroupTransactionAsync(GetGroupTransactionWebRequest request)
        {
            var serviceRequest = request.ToGetGroupTransactionRequest();
            var result = await _transactionService.GetGroupTransactionAsync(serviceRequest);
            return this.CreateResponse(result.AsGetGroupTransactionWebResponse());
        }

        [HttpPatch("update")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UpdateTransactionWebResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UpdateTransactionWebResponse))]
        public async Task<IActionResult> UpdateTransactionAsync(UpdateTransactionWebRequest request)
        {
            var serviceRequest = request.ToUpdateTransactionRequest();
            var result = await _transactionService.UpdateTransactionAsync(serviceRequest);
            return this.CreateResponse(result.AsUpdateTransactionWebResponse());
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteTransactionWebRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(DeleteTransactionWebRequest))]
        public async Task<IActionResult> DeleteTransactionAsync(DeleteTransactionWebRequest request)
        {
            var serviceRequest = request.ToDeleteTransactionRequest();
            var result = await _transactionService.DeleteTransactionAsync(serviceRequest);
            return this.CreateResponse(result.AsDeleteTransactionWebResponse());
        }
    }
}
