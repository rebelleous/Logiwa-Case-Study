using Logiwa_CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Services
{
    public interface IProductService
    {
        List<Product> ListAllProducts();

        List<Product> SearchByCriteria(string title, string description, string categoryName); // entity framework search, bycriteria, filtering

        List<Product> SearchByStockRange(int minVal=1, int maxVal=200);

        void Create(CrUpProduct model);

        void Update(int id, CrUpProduct model);

        void Delete(int id);
    }
}
