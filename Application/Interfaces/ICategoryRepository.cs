using Domain.Models;
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
    }
}
