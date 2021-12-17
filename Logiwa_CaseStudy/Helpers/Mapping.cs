using AutoMapper;
using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Models.Dtos;

namespace Logiwa_CaseStudy.Helpers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, CreateUpdateProductDto>().ReverseMap(); // Mapping for Product-Product CRUD dto
            CreateMap<Product, GetProductDto>().ForMember(model => model.categoryName, opts => opts.MapFrom(src => src.category.Name)).ReverseMap(); // Mapping for GetProduct by categoryname
            CreateMap<Category, CreateCategoryDto>().ReverseMap(); // Mapping for Category-Category CRUD dto
        }
    }
}
