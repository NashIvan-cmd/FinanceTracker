using System;
using FinanceTracker.Infrastructure.Messages;
using FinanceTracker.Infrastructure.Messages.Transaction;
using System.Threading.Tasks;


namespace FinanceTracker.Infrastructure.Services.Interfaces;

public interface ITransactionService
{
    Task<Response<CreateBulkTransactionResult>> CreateBulkTransactionAsync(CreateBulkTransactionRequest request);

    Task<Response<GetBulkTransactionResponse>> GetBulkTransactionAsync(GetTransactionRequest request);

    Task<Response<GetGroupTransactionResponse>> GetGroupTransactionAsync(GetGroupTransactionRequest result);

    Task<Response<UpdateTransactionResult>> UpdateTransactionAsync(UpdateTransactionRequest result);

    Task<Response<DeleteTransactionResponse>> DeleteTransactionAsync(DeleteTransactionRequest result);
}
