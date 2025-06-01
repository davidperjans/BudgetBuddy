using Application.Features.TransactionFeatures.Commands;
using Application.Interfaces;
using Application.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.TransactionFeatures.Handlers
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, OperationResult<Transaction>>
    {
        private readonly ITransactionService _transactionService;

        public UpdateTransactionCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<OperationResult<Transaction>> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction
            {
                Id = request.TransactionDto.Id,
                UserId = request.TransactionDto.UserId,
                Amount = request.TransactionDto.Amount,
                Description = request.TransactionDto.Description,
                Date = request.TransactionDto.Date,
                IsIncome = request.TransactionDto.IsIncome
            };

            var updated = await _transactionService.UpdateTransactionAsync(transaction);

            if (!updated)
                return OperationResult<Transaction>.Failure("Transaction not found or update failed.");

            return OperationResult<Transaction>.Success(transaction);
        }
    }
}
