using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    // Service implementation that handles all transaction logic
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _dbContext;

        public TransactionService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Create and save a new transaction
        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            transaction.Id = Guid.NewGuid();
            _dbContext.Transactions.Add(transaction);
            await _dbContext.SaveChangesAsync();
            return transaction;
        }

        // Get all transactions for a specific user
        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync(Guid userId)
        {
            return await _dbContext.Transactions
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }

        // Get a transaction by its ID
        public async Task<Transaction?> GetTransactionByIdAsync(Guid id)
        {
            return await _dbContext.Transactions.FindAsync(id);
        }

        // Update an existing transaction
        public async Task<bool> UpdateTransactionAsync(Transaction transaction)
        {
            var existingTransaction = await _dbContext.Transactions.FindAsync(transaction.Id);

            if (existingTransaction == null)
                return false;

            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Description = transaction.Description;
            existingTransaction.Date = transaction.Date;
            existingTransaction.IsIncome = transaction.IsIncome;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        // Delete a transaction by ID
        public async Task<bool> DeleteTransactionAsync(Guid id)
        {
            var transaction = await _dbContext.Transactions.FindAsync(id);
            if (transaction == null)
                return false;

            _dbContext.Transactions.Remove(transaction);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
