using Application.Common;
using Application.Features.TransactionFeatures.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.TransactionFeatures.Handlers
{
    public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, OperationResult<List<Transaction>>>
    {
        private readonly ITransactionService _transactionService;

        public GetAllTransactionsHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<OperationResult<List<Transaction>>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionService.GetAllTransactionsAsync(request.UserId);

            return OperationResult<List<Transaction>>.Success(transactions.ToList());
        }
    }
}
