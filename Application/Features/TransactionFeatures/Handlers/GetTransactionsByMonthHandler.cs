using Application.Features.TransactionFeatures.Queries;
using Application.Interfaces;
using Application.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.TransactionFeatures.Handlers
{
    public class GetTransactionsByMonthHandler : IRequestHandler<GetTransactionsByMonthQuery, OperationResult<List<Transaction>>>
    {
        private readonly ITransactionService _transactionService;

        public GetTransactionsByMonthHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<OperationResult<List<Transaction>>> Handle(GetTransactionsByMonthQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionService.GetAllTransactionsAsync(request.UserId);

            var filtered = transactions
                .Where(t => t.Date.Year == request.Year && t.Date.Month == request.Month)
                .ToList();

            return OperationResult<List<Transaction>>.Success(filtered);
        }
    }
}
