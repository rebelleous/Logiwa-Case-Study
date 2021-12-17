using AutoMapper;
using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Services;
using Microsoft.AspNetCore.Mvc;


namespace Logiwa_CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryService.ListAllCategories());
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto model)
        {
            _categoryService.Create(model);
            return Ok(new { mesage = "Category created." });
        }

        [HttpPut]
        /// Update function w HttpPut
        public IActionResult Update(int id, CreateCategoryDto model)
        {
            _categoryService.Update(id, model);
            return Ok(new { message = "Category updated." });
        }

        [HttpDelete("{id}")]
        /// Delete function w HttpDelete
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok(new { message = "Category deleted." });
        }


    }
}
