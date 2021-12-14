using AutoMapper;
using Logiwa_CaseStudy.Models;
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
            CreateMap<Product, CrUpProduct>().ForMember(model => model.CategoryID, opts => opts.MapFrom(src => src.category.ID)).ReverseMap();
            CreateMap<Category, CreateCategory>().ReverseMap();
        }
    }
}
