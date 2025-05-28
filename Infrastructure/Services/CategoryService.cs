using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Application.Common;

namespace Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCategoryDto> _validator;

        public CategoryService(AppDbContext context, IMapper mapper, IValidator<CreateCategoryDto> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<OperationResult<CategoryDto>> CreateAsync(CreateCategoryDto dto)
        {
            var validation = await _validator.ValidateAsync(dto);
            if (!validation.IsValid)
            {
                var error = string.Join("; ", validation.Errors.Select(e => e.ErrorMessage));
                return OperationResult<CategoryDto>.Failure(error);
            }

            // DB-validering här istället
            bool exists = await _context.Categories
                .AnyAsync(c => c.UserId == dto.UserId && c.Name.ToLower() == dto.Name.ToLower());

            if (exists)
                return OperationResult<CategoryDto>.Failure("Category already exists for this user.");

            var category = _mapper.Map<Category>(dto);
            category.CategoryId = Guid.NewGuid();

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map<CategoryDto>(category);
            return OperationResult<CategoryDto>.Success(resultDto);
        }
    }
}


