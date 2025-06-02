using Application.DTOs;
using Application.Features.TransactionFeatures.Commands;
using Application.Features.TransactionFeatures.Handlers;
using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests.Features.TransactionsFeatures
{
    public class CreateTransactionHandlerTests
    {
        [Test]
        public async Task CreateAsync_ShouldReturnSuccess_WhenValid()
        {
            // Setup InMemory EF Core
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TransactionTestDb")
                .Options;

            using (var context = new AppDbContext(options))
            {
                // Setup real service 
                var service = new TransactionService(context);

                // Arrange
                var dto = new CreateTransactionDto
                {
                    UserId = Guid.NewGuid(),
                    Amount = 150,
                    Description = "Test Transaction",
                    Date = DateTime.UtcNow,
                    IsIncome = true
                };

                var command = new CreateTransactionCommand(dto);
                var handler = new CreateTransactionCommandHandler(service);

                // Act
                var result = await handler.Handle(command, CancellationToken.None);

                // Assert
                Assert.That(result.IsSuccess, Is.True);

                var saved = await context.Transactions.FirstOrDefaultAsync(t => t.Id == result.Data!.Id);

                Assert.That(saved, Is.Not.Null);
                Assert.That(saved.Amount, Is.EqualTo(dto.Amount));
                Assert.That(saved.Description, Is.EqualTo(dto.Description));
                Assert.That(saved.IsIncome, Is.EqualTo(dto.IsIncome));
                Assert.That(saved.UserId, Is.EqualTo(dto.UserId));

            }
        }
    }
}
