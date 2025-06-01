using Domain.Entities;

namespace Application.Interfaces
{
    
    public interface ITransactionService
    {
        Task<Transaction> CreateTransactionAsync(Transaction transaction);

        Task<IEnumerable<Transaction>> GetAllTransactionsAsync(Guid userId);

        Task<Transaction?> GetTransactionByIdAsync(Guid id);

        Task<bool> UpdateTransactionAsync(Transaction transaction);

        Task<bool> DeleteTransactionAsync(Guid id);
    }
}
