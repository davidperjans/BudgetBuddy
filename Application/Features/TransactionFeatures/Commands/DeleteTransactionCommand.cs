using Application.Common;
using Application.DTOs;
using MediatR;

namespace Application.Features.TransactionFeatures.Commands
{
    public class DeleteTransactionCommand : IRequest<OperationResult<bool>>
    {
        public DeleteTransactionDto TransactionDto { get; set; }

        public DeleteTransactionCommand(DeleteTransactionDto transactionDto)
        {
            TransactionDto = transactionDto;
        }
    }
}
