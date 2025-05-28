using Application.Common;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFetures.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<OperationResult<string>>
    {
        public DeleteCategoryDto Dto { get; set; }

        public DeleteCategoryCommand(DeleteCategoryDto dto)
        {
            Dto = dto;
        }
    }
}
