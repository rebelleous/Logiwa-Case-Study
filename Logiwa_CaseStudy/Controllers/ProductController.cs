using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Logiwa_CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet("[action]")] // [HttpGet] birden fazla Get fonk. olduğunda action ismini veriyor.

        public IEnumerable<Product> Get()
        {
            return _productService.ListAllProducts();
        }


        [HttpGet("[action]")]
        public IEnumerable<Product> GetByCriteria(string title = "", string description = "", string categoryName = "") // bu fonksiyonlara da Get verip override ile aynı isime sahiplendirebilirdim.
        {
            return _productService.SearchByCriteria(title, description, categoryName);
        }

        [HttpGet("[action]")]
        public IEnumerable<Product> GetByQuantity(int minVal = 1, int maxVal = 200)
        {
            return _productService.SearchByStockRange(minVal, maxVal);
        }



    }
}
