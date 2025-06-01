using Application.Common;
using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.TransactionFeatures.Commands
{
    public class UpdateTransactionCommand : IRequest<OperationResult<Transaction>>
    {
        public UpdateTransactionDto TransactionDto { get; set; }

        public UpdateTransactionCommand(UpdateTransactionDto transactionDto)
        {
            TransactionDto = transactionDto;
        }
    }
}
