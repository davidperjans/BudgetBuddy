using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<bool>DoseCategoryExistAsync(string name);
        Task<bool> DeleteCategory(Guid categoryid);
        Task<List<Category>> GetAllByUserIdAsync(Guid userId, CancellationToken token);
        Task<Category?> GetByIdAsync(Guid categoryid, CancellationToken token);

    }
}
