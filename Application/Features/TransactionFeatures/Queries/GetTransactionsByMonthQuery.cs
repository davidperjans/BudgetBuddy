using Application.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.TransactionFeatures.Queries
{
    public class GetTransactionsByMonthQuery : IRequest<OperationResult<List<Transaction>>>
    {
        public Guid UserId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public GetTransactionsByMonthQuery(Guid userId, int year, int month)
        {
            UserId = userId;
            Year = year;
            Month = month;
        }
    }
}
