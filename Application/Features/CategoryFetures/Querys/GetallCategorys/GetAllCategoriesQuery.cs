using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFetures.Querys.GetallCategorys
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
    {
        public Guid UserId { get; }

        public GetAllCategoriesQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
