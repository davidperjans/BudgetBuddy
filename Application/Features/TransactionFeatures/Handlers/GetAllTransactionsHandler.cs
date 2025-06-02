using Application.Common;
using Application.DTOs;
using Application.Features.TransactionFeatures.Queries;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TransactionFeatures.Handlers
{
    public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, OperationResult<List<TransactionDto>>>
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public GetAllTransactionsHandler(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<TransactionDto>>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionService.GetAllTransactionsAsync(request.UserId);

            var transactionDtos = _mapper.Map<List<TransactionDto>>(transactions);

            return OperationResult<List<TransactionDto>>.Success(transactionDtos);
        }
    }
}
