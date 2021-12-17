using AutoMapper;
using Logiwa_CaseStudy.Extensions;
using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;


        public ProductService(ApplicationDBContext context, IMapper mapper, ICacheService cacheService)
        {
            _context = context;
            _mapper = mapper; // işkence satırı
            _cacheService = cacheService;
        }


        public List<GetProductDto> ListAllProducts()
        {

            return _mapper.Map<List<GetProductDto>>(_context.Products.Include(m=> m.category).ToList());
        }

        public async Task<List<Product>> SearchByCriteria(string title, string description, string categoryName)
        {
            string redisId = title + "-" + description + "-" + categoryName;
            var productsFromCache = await _cacheService.GetAsync<List<Product>>(redisId);
            if(productsFromCache is not null)
            {
                return productsFromCache;
            }
            else
            {
                var products= await _context.Products
                    .Where(m => m.Title.ToLower().Contains(title.ToLower()) && m.Description.ToLower().Contains(description.ToLower()) && m.category.Name.ToLower().Contains(categoryName.ToLower()))
                    .ToListAsync();
                
                await _cacheService.SetAsync(redisId, products);
                return products;

            
            }
        }

        public async Task<List<Product>> SearchByStockRange(int minVal, int maxVal)
        {
            string redisId = minVal + "-" + maxVal;
            var productsFromCache = await _cacheService.GetAsync<List<Product>>(redisId);
            if (productsFromCache is not null)
            {
                return productsFromCache;
            }
            else
            {
                var products = await _context.Products.Where(m => m.StockQuantity >= minVal && m.StockQuantity <= maxVal).ToListAsync();
                await _cacheService.SetAsync(redisId, products);
                return products;
            }
            
        }

        

        public void Create(CrUpProduct model)
        {
            var product = _mapper.Map<Product>(model);
            _context.Products.Add(product); // Flag for adding
            _context.SaveChanges(); //Controller isteği karşılar sonra middleware a bakar sonrası servise düşer. Servisten veritabanına flag koyar. Veritabanı bunu uygular ve geri döner.
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
