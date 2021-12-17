using AutoMapper;
using Logiwa_CaseStudy.Controllers;
using Logiwa_CaseStudy.Helpers;
using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Logiwa_CaseStudy_UnitTest
{
    public class CategoryTest
    {

        #region Static Objects

        List<Category> categories = new List<Category>
            {
                        new Category(){Name="Elektronik",MinStockQuantity=5},

            };
        static Mapping myProfile = new Mapping();
        static MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        IMapper mapper = new Mapper(configuration);

        #endregion

        #region OkResult Testleri
        [Fact]
        public void Task_GetCategories_Return_OkResult()
        {

            var mockRepo = new Mock<ICategoryService>();
            mockRepo.Setup(repo => repo.ListAllCategories());

            var mockController = new CategoryController(mockRepo.Object, mapper);

            //Act  
            var data = mockController.Get();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_CreateCategories_Return_OkResult()
        {

            var mockRepo = new Mock<ICategoryService>();
            mockRepo.Setup(repo => repo.Create(new CreateCategoryDto()));

            var mockController = new CategoryController(mockRepo.Object, mapper);

            //Act  
            var data = mockController.Create(new CreateCategoryDto());

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_UpdateCategories_Return_OkResult()
        {

            var mockRepo = new Mock<ICategoryService>();
            mockRepo.Setup(repo => repo.Update(1, new CreateCategoryDto()));

            var mockController = new CategoryController(mockRepo.Object, mapper);

            //Act  
            var data = mockController.Update(1, new CreateCategoryDto());

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_DeleteCategories_Return_OkResult()
        {

            var mockRepo = new Mock<ICategoryService>();
            mockRepo.Setup(repo => repo.Delete(1));

            var mockController = new CategoryController(mockRepo.Object, mapper);

            //Act  
            var data = mockController.Delete(1);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
        #endregion

        #region Equal Testleri
        [Fact]
        public void Task_GetCategories_Return_GreaterThanOne()
        {

            var mockRepo = new Mock<ICategoryService>();
            mockRepo.Setup(repo => repo.ListAllCategories()).Returns(categories);

            var mockController = new CategoryController(mockRepo.Object, mapper);
            var OkResult = Assert.IsType<OkObjectResult>(mockController.Get());
            //Act  
            var returnCategories = Assert.IsAssignableFrom<List<Category>>(OkResult.Value);
            var countSize = returnCategories.ToList().Count;

            //Assert  
            Assert.Equal(1, countSize);
        }
        #endregion
    }
}