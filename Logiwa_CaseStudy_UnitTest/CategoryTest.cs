using AutoMapper;
using Logiwa_CaseStudy.Controllers;
using Logiwa_CaseStudy.Helpers;
using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Logiwa_CaseStudy_UnitTest
{
    public class CategoryTest
    {

        [Fact]
        public void Task_GetCategories_Return_OkResult()
        {
            var myProfile = new Mapping();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);


            var mockRepo = new Mock<ICategoryService>();
            mockRepo.Setup(repo => repo.ListAllCategories());

            var mockController = new CategoryController(mockRepo.Object, mapper);

            //Act  
            var data = mockController.Get();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetCategories_Return_GreaterThanOne()
        {
            var myProfile = new Mapping();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            var categories = new List<Category> 
            {
                        new Category(){Name="Elektronik",MinStockQuantity=5},
                        new Category(){Name="Moda",MinStockQuantity=10},
                        new Category(){Name="Spor",MinStockQuantity=15},
                        new Category(){Name="Otomotiv",MinStockQuantity=20}, 
            };

            var mockRepo = new Mock<ICategoryService>();
            mockRepo.Setup(repo => repo.ListAllCategories()).Returns(categories);

            var mockController = new CategoryController(mockRepo.Object, mapper);
            var OkResult = Assert.IsType<OkObjectResult>(mockController.Get());
            //Act  
            var returnCategories = Assert.IsAssignableFrom<List<Category>>(OkResult.Value);
            var data = returnCategories.ToList().Count;

            //Assert  
            Assert.True(data >= 4, "Expected value greater than 4");
        }
    }
}
