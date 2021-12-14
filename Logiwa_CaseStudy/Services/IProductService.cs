using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Services
{
    public interface IProductService
    {
        List<GetProductDto> ListAllProducts();

        List<Product> SearchByCriteria(string title, string description, string categoryName); // entity framework search, bycriteria, filtering

        List<Product> SearchByStockRange(int minVal, int maxVal);

        void Create(CrUpProduct model);

        void Update(int id, CrUpProduct model);

        void Delete(int id);
    }
}
