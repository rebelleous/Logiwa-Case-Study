using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using static Logiwa_CaseStudy.Models.CacheCategory;
using Bogus;

namespace Logiwa_CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        public TestController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            //var cat = Bogus.DataSets.Commerce.Categories().Lorem(locale: "tr");
            var models = await _cacheService.GetAsync<List<CacheCategory>>("models") ?? new List<CacheCategory>();
            var model = new CacheCategory(Faker.Address.City(), Faker.RandomNumber.Next(100));
            models.Add(model);
            await _cacheService.SetAsync("models", models);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var models = await _cacheService.GetAsync<List<CacheCategory>>("models");
            if (models != null)
            {
                try
                {
                    var guidId = new Guid(id);
                    var model = models.FirstOrDefault(p => p.Id == guidId);
                    if (model != null)
                    {
                        return Ok(model);
                    }
                }
                catch (System.Exception)
                {
                }
            }
            return BadRequest("Product can not be found.");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var cache = await _cacheService.GetAsync<List<CacheCategory>>("models");

            return Ok(cache);
        }


    }
}
