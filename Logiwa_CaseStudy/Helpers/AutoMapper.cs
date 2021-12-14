using AutoMapper;
using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Helpers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, CrUpProduct>().ReverseMap();
            CreateMap<Product, GetProductDto>().ForMember(model => model.categoryName, opts => opts.MapFrom(src => src.category.Name)).ReverseMap();
            CreateMap<Category, CreateCategory>().ReverseMap();
        }
    }
}
