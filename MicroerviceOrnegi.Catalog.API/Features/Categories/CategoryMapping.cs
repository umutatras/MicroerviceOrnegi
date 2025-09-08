using AutoMapper;
using MicroerviceOrnegi.Catalog.API.Features.Categories.Dtos;

namespace MicroerviceOrnegi.Catalog.API.Features.Categories
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
