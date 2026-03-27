using System;
using System.Collections.Generic;
using System.Linq;
using FinanceTracker.Api.Messages.Transaction;
using FinanceTracker.Infrastructure.Messages;
using FinanceTracker.Infrastructure.Messages.Transaction;

namespace FinanceTracker.Api.Extensions.Models;

public static class TransactionExtension
{
    // Request mapping methods
    public static CreateBulkTransactionRequest ToCreateBulkTransactionRequest(this CreateBulkTransactionWebRequest webRequest)
    {
        return new CreateBulkTransactionRequest
        {
            Transactions = webRequest.Transactions.Select(t => new CreateTransactionRequest
            {
                IsNecessity = t.IsNecessity,
                Amount = t.Amount,
                Type = t.Type,
                Description = t.Description,
                Notes = t.Notes,
                Group = t.Group,
            }).ToList()
        };
    }

    public static GetTransactionRequest ToGetTransactionRequest(this GetBulkTransactionWebRequest webRequest)
    {
        return new GetTransactionRequest
        {
            TransactionId = webRequest.TransactionId
        };
    }

    public static GetGroupTransactionRequest ToGetGroupTransactionRequest(this GetGroupTransactionWebRequest webRequest)
    {
        return new GetGroupTransactionRequest
        {
            GroupId = webRequest.GroupId
        };
    }

    public static UpdateTransactionRequest ToUpdateTransactionRequest(this UpdateTransactionWebRequest webRequest)
    {
        return new UpdateTransactionRequest
        {
            TransactionId = webRequest.TransactionId,
            IsNecessity = webRequest.IsNecessity,
            Amount = webRequest.Amount,
            Type = webRequest.Type,
            Description = webRequest.Description,
            Notes = webRequest.Notes,
        };
    }

    public static DeleteTransactionRequest ToDeleteTransactionRequest(this DeleteTransactionWebRequest webRequest)
    {
        return new DeleteTransactionRequest
        {
            TransactionId = webRequest.TransactionId
        };
    }

    // Response mapping methods
    public static CreateBulkTransactionWebResponse AsCreateBulkTransactionWebResponse(this Response<CreateBulkTransactionResult> response)
    {
        return new CreateBulkTransactionWebResponse(response.Data, response.ErrorCode, response.Message);
    }

    public static GetBulkTransactionWebResponse AsGetBulkTransactionWebResponse(this Response<GetBulkTransactionResponse> response)
    {
        return new GetBulkTransactionWebResponse(response.Data, response.ErrorCode, response.Message);
    }

    public static GetGroupTransactionWebResponse AsGetGroupTransactionWebResponse(this Response<GetGroupTransactionResponse> response)
    {
        return new GetGroupTransactionWebResponse(response.Data, response.ErrorCode, response.Message);
    }

    public static UpdateTransactionWebResponse AsUpdateTransactionWebResponse(this Response<UpdateTransactionResult> response)
    {
        return new UpdateTransactionWebResponse(response.Data, response.ErrorCode, response.Message);
    }

    public static DeleteTransactionWebResponse AsDeleteTransactionWebResponse(this Response<DeleteTransactionResponse> response)
    {
        return new DeleteTransactionWebResponse(response.Data, response.ErrorCode, response.Message);
    }
}
