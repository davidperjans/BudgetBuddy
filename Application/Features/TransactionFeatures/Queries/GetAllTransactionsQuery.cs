using Application.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.TransactionFeatures.Queries
{
    public class GetAllTransactionsQuery : IRequest<OperationResult<List<Transaction>>>
    {
        public Guid UserId { get; set; }

        public GetAllTransactionsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
