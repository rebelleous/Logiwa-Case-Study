using AutoMapper;
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
        private IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

       

        
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

        [HttpPost]
        public IActionResult Create(CrUpProduct model)
        {
            _productService.Create(model);
            return Ok(new { mesage = "Product created." });
        }

        [HttpPut]
        public IActionResult Update(int id, CrUpProduct model)
        {
            _productService.Update(id, model);
            return Ok(new { message = "Product updated." });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok(new { message = "Product deleted." });
        }
    }
}
