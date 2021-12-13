using Logiwa_CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext _context;
        public ProductService(ApplicationDBContext context)
        {
            _context = context;
        }


        public List<Product> ListAllProducts()
        {

            return _context.Products.ToList();
        }

        public Task<Product> ListProductCategoryByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
