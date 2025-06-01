using Application.Common;
using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.TransactionFeatures.Commands
{
    public class CreateTransactionCommand : IRequest<OperationResult<Transaction>>
    {
        public CreateTransactionDto TransactionDto { get; set; }

        public CreateTransactionCommand(CreateTransactionDto transactionDto)
        {
            TransactionDto = transactionDto;
        }
    }
}
