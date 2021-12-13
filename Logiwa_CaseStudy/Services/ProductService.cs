using Logiwa_CaseStudy.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<Product> SearchByCriteria(string title, string description, string categoryName)
        {
            
            return _context.Products.Where(m => m.Title.ToLower().Contains(title.ToLower()) && m.Description.ToLower().Contains(description.ToLower()) && m.category.Name.ToLower().Contains(categoryName.ToLower())).ToList();
        }

        public List<Product> SearchByStockRange(int minVal = 1, int maxVal = 200)
        {
            return _context.Products.Where(m => m.StockQuantity >= minVal && m.StockQuantity <= maxVal).ToList();
        }
    }
}
