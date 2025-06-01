using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistsByEmailAsync(string email);
        Task AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task<List<User>> GetAllAsync();
    }
}