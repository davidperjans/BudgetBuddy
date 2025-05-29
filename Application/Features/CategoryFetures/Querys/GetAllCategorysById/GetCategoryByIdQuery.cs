using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFetures.Querys.GetAllCategorysById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto?>
    {
        public Guid CategoryId { get; }

        public GetCategoryByIdQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }

}
