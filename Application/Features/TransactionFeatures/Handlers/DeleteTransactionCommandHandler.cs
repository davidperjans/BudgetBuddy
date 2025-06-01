using Application.Features.TransactionFeatures.Commands;
using Application.Interfaces;
using Application.Common;
using MediatR;

namespace Application.Features.TransactionFeatures.Handlers
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, OperationResult<bool>>
    {
        private readonly ITransactionService _transactionService;

        public DeleteTransactionCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<OperationResult<bool>> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _transactionService.DeleteTransactionAsync(request.TransactionDto.Id);

            if (!deleted)
                return OperationResult<bool>.Failure("Transaction not found or delete failed.");

            return OperationResult<bool>.Success(true);
        }
    }
}
