using AutoMapper;
using Logiwa_CaseStudy.Controllers;
using Logiwa_CaseStudy.Helpers;
using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Models.Dtos;
using Logiwa_CaseStudy.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logiwa_CaseStudy_UnitTest
{
    public class ProductTest
    {

        #region Static Objects

        List<Product> products = new List<Product>
            {
                        new Product() {Description="Karşınızda şimdiye kadarki en hızlı ve en güçlü Xbox olan Xbox Series X.",StockQuantity=40,CategoryID=1,Title="Microsoft Xbox Series X Oyun Konsolu Siyah 1 TB"},

            };
        static Mapping myProfile = new Mapping();
        static MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        IMapper mapper = new Mapper(configuration);

        #endregion

        #region OkResult Testleri

        [Fact]
        public void Task_GetProducts_Return_OkResult()
        {

            var mockRepo = new Mock<IProductService>();
            mockRepo.Setup(repo => repo.ListAllProducts());

            var mockController = new ProductController(mockRepo.Object, mapper);

            //Act  
            var data = mockController.Get();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_CreateProducts_Return_OkResult()
        {

            var mockRepo = new Mock<IProductService>();
            mockRepo.Setup(repo => repo.Create(new CrUpProduct()));

            var mockController = new ProductController(mockRepo.Object, mapper);

            //Act  
            var data = mockController.Create(new CrUpProduct());

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_UpdateProducts_Return_OkResult()
        {

            var mockRepo = new Mock<IProductService>();
            mockRepo.Setup(repo => repo.Update(1, new CrUpProduct()));

            var mockController = new ProductController(mockRepo.Object, mapper);

            //Act  
            var data = mockController.Update(1, new CrUpProduct());

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_DeleteProducts_Return_OkResult()
        {

            var mockRepo = new Mock<IProductService>();
            mockRepo.Setup(repo => repo.Delete(1));

            var mockController = new ProductController(mockRepo.Object, mapper);

            //Act  
            var data = mockController.Delete(1);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_SearchByStockRangeProducts_Return_OkResult()
        {

            var mockRepo = new Mock<IProductService>();
            mockRepo.Setup(repo => repo.SearchByStockRange(1, 200));

            var mockController = new ProductController(mockRepo.Object, mapper);

            //Act  
            var data = await mockController.GetByQuantity();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_SearchByCriteria_Return_OkResult()
        {

            var mockRepo = new Mock<IProductService>();
            mockRepo.Setup(repo => repo.SearchByCriteria("a", "a", "e"));

            var mockController = new ProductController(mockRepo.Object, mapper);

            //Act  
            var data = await mockController.GetByCriteria();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }


        #endregion


        #region Equal Testleri


        [Fact]
        public async Task Task_SearchByStockRangeProducts_Return_EqualCountAsync()
        {

            var mockRepo = new Mock<IProductService>();
            mockRepo.Setup(repo => repo.SearchByStockRange(30, 50)).ReturnsAsync(products);

            var mockController = new ProductController(mockRepo.Object, mapper);
            var OkResult = Assert.IsType<OkObjectResult>(await mockController.GetByQuantity(30, 50));
            //Act  
            var returnProducts = Assert.IsAssignableFrom<List<Product>>(OkResult.Value);
            var countSize = returnProducts.ToList().Count;

            //Assert  
            Assert.Equal(1, countSize);
        }

        [Fact]
        public async void Task_SearchByCriteria_Return_EqualCount()
        {

            var mockRepo = new Mock<IProductService>();
            mockRepo.Setup(repo => repo.SearchByCriteria("a", "a", "e")).ReturnsAsync(products);

            var mockController = new ProductController(mockRepo.Object, mapper);
            var OkResult = Assert.IsType<OkObjectResult>(await mockController.GetByCriteria("a", "a", "e"));
            //Act  
            var returnProducts = Assert.IsAssignableFrom<List<Product>>(OkResult.Value);
            var countSize = returnProducts.ToList().Count;

            //Assert  
            Assert.Equal(1, countSize);
        }

        [Fact]
        public void Task_GetProducts_Return_EqualCount()
        {

            var mockRepo = new Mock<IProductService>();
            mockRepo.Setup(repo => repo.ListAllProducts()).Returns(mapper.Map<List<GetProductDto>>(products));

            var mockController = new ProductController(mockRepo.Object, mapper);
            var OkResult = Assert.IsType<OkObjectResult>(mockController.Get());
            //Act  
            var returnProducts = Assert.IsAssignableFrom<List<GetProductDto>>(OkResult.Value);
            var countSize = returnProducts.ToList().Count;

            //Assert  
            Assert.Equal(1, countSize);
        }

        #endregion
    }
}
