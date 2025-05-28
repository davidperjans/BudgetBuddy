using Application.Common;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<OperationResult<CategoryDto>> CreateAsync(CreateCategoryDto dto);
    }
}


