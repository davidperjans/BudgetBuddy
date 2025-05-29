using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFetures.Commands.CreateACategory
{
    public class CreateCategoryCommand : IRequest<OperationResult<string>>
    {
        public CreateCategoryDto Dto { get; set; }

        public CreateCategoryCommand(CreateCategoryDto dto)
        {
            Dto = dto;
        }
    }
}
