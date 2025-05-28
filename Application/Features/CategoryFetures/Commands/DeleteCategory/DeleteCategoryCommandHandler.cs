using Application.Common;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFetures.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, OperationResult<string>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<OperationResult<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.DeleteCategory(request.Dto.CategoryId);

            if (!result) return OperationResult<string>.Failure("Category not exist");

            return OperationResult<string>.Success("Category removed");
        }
    }
}
