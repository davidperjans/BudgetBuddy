using AutoMapper;
using Application.DTOs;
using Domain.Models;


namespace Application.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}


