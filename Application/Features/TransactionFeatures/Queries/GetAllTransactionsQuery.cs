using Application.Common;
using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.TransactionFeatures.Queries
{
    public class GetAllTransactionsQuery : IRequest<OperationResult<List<TransactionDto>>>
    {
        public Guid UserId { get; set; }

        public GetAllTransactionsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
