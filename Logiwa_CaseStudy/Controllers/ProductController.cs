using AutoMapper;
using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


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

              
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.ListAllProducts());
        }

        [HttpGet("[action]")] 
        public async Task<IActionResult> GetByCriteria(string title = "", string description = "", string categoryName = "") //Redis'e outsource request atarken SQL verisini bekletmek amacıyla Async yapıldı. 
        {
            return Ok(await _productService.SearchByCriteria(title, description, categoryName));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByQuantity(int minVal = 1, int maxVal = 200) // default parameter.
        {
            return Ok(await _productService.SearchByStockRange(minVal, maxVal)); // Search by stock range
        }

        [HttpPost]
        /// Create function w HttpPost
        public IActionResult Create(CreateUpdateProductDto model) 
        {
            _productService.Create(model);
            return Ok(new { mesage = "Product created." });
        }

        [HttpPut]
        /// Update function w HttpPut
        public IActionResult Update(int id, CreateUpdateProductDto model) 
        {
            _productService.Update(id, model);
            return Ok(new { message = "Product updated." });
        }

        [HttpDelete("{id}")]
        /// Delete function w HttpDelete
        public IActionResult Delete(int id) 
        {
            _productService.Delete(id);
            return Ok(new { message = "Product deleted." });
        }
    }
}
