using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Services
{
    public interface IProductService
    {
        List<GetProductDto> ListAllProducts();

        Task<List<Product>> SearchByCriteria(string title, string description, string categoryName); 

        Task<List<Product>> SearchByStockRange(int minVal, int maxVal);

        void Create(CreateUpdateProductDto model);

        void Update(int id, CreateUpdateProductDto model);

        void Delete(int id);
    }
}
