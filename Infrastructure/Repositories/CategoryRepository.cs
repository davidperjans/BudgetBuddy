using Application.Interfaces;
using Domain.Models;
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

        public async Task<bool> DoseCategoryExistAsync(string name)
        {
            return await _appDbContext.Categories.AnyAsync(c => c.Name.ToLower() == name.ToLower());
        }


    }
}
