using AutoMapper;
using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Models.Dtos;
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
        private readonly IMapper _mapper;

        public ProductService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; // işkence satırı
        }


        public List<GetProductDto> ListAllProducts()
        {

            return _mapper.Map<List<GetProductDto>>(_context.Products.Include(m=> m.category).ToList());
        }

        public List<Product> SearchByCriteria(string title, string description, string categoryName)
        {
            
            return _context.Products.Where(m => m.Title.ToLower().Contains(title.ToLower()) && m.Description.ToLower().Contains(description.ToLower()) && m.category.Name.ToLower().Contains(categoryName.ToLower())).ToList();
        }

        public List<Product> SearchByStockRange(int minVal, int maxVal)
        {
            return _context.Products.Where(m => m.StockQuantity >= minVal && m.StockQuantity <= maxVal).ToList();
        }

        

        public void Create(CrUpProduct model)
        {
            var product = _mapper.Map<Product>(model);
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(int id, CrUpProduct model)
        {

            var product =_mapper.Map<Product>(model);
            _context.Products.Update(product);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var product = getProduct(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        private Product getProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) throw new KeyNotFoundException("Product not found");
            return product;
        }


    }
}
