using Application.Features.TransactionFeatures.Queries;
using Application.Interfaces;
using Application.Common;
using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.TransactionFeatures.Handlers
{
    public class GetTransactionStatisticsHandler : IRequestHandler<GetTransactionStatisticsQuery, OperationResult<TransactionStatisticsDto>>
    {
        private readonly ITransactionService _transactionService;

        public GetTransactionStatisticsHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<OperationResult<TransactionStatisticsDto>> Handle(GetTransactionStatisticsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionService.GetAllTransactionsAsync(request.UserId);

            var income = transactions.Where(t => t.IsIncome).Sum(t => t.Amount);
            var expense = transactions.Where(t => !t.IsIncome).Sum(t => t.Amount);

            var stats = new TransactionStatisticsDto
            {
                TotalIncome = income,
                TotalExpense = expense
            };

            return OperationResult<TransactionStatisticsDto>.Success(stats);
        }
    }
}
