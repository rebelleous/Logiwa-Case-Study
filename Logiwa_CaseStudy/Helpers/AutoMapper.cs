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
            CreateMap<CreateProduct, Product>();//.ForMember(model => model.category, opts => opts.MapFrom(src => src.category.Name)).ReverseMap();
            CreateMap<CreateCategory, Category>();//.ReverseMap();
        }
    }
}
