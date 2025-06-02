using Application.Common;
using Application.DTOs;
using MediatR;

namespace Application.Features.TransactionFeatures.Queries
{
    public class GetTransactionStatisticsQuery : IRequest<OperationResult<TransactionStatisticsDto>>
    {
        public Guid UserId { get; set; }

        public GetTransactionStatisticsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
