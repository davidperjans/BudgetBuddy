using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Category category)
        {
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteCategory(Guid categoryid)
        {
            var category = await _appDbContext.Categories.FindAsync(categoryid);
            if (category == null) return false;

            _appDbContext.Categories.Remove(category);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DoseCategoryExistAsync(string name, Guid userId)
        {
            return await _appDbContext.Categories.AnyAsync(c => c.Name.ToLower() == name.ToLower() && c.UserId == userId);
        }

        public async Task<List<Category>> GetAllByUserIdAsync(Guid userId, CancellationToken token)
        {
            return await _appDbContext.Categories
                .Where(c => c.UserId == userId)
                .ToListAsync(token);
        }

        public async Task<Category?> GetByIdAsync(Guid categoryid, CancellationToken token)
        {
            return await _appDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryid, token);
        }



    }
}
