using Application.Common;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFetures.Commands.CreateACategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, OperationResult<string>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            bool exist = await _categoryRepository.DoseCategoryExistAsync(dto.Name);

            if (exist) return OperationResult<string>.Failure("Category alredy exist");

            var category = _mapper.Map<Category>(dto);
            category.CategoryId = Guid.NewGuid();

            //TODO: USERID BEHÖVER IMPLEMENTERAS.
            category.UserId = Guid.Parse("41718d10-7505-425d-b32c-08dd9cfbed43");

            await _categoryRepository.AddAsync(category);

            return OperationResult<string>.Success("You have added the category");


        }
    }
}
