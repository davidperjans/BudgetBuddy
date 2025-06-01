using Application.Features.TransactionFeatures.Commands;
using Application.Interfaces;
using Application.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.TransactionFeatures.Handlers
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, OperationResult<Transaction>>
    {
        private readonly ITransactionService _transactionService;

        public CreateTransactionCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<OperationResult<Transaction>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction
            {
                UserId = request.TransactionDto.UserId,
                Amount = request.TransactionDto.Amount,
                Description = request.TransactionDto.Description,
                Date = request.TransactionDto.Date,
                IsIncome = request.TransactionDto.IsIncome
            };

            var created = await _transactionService.CreateTransactionAsync(transaction);

            return OperationResult<Transaction>.Success(created);
        }
    }
}
