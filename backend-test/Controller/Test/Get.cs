using backend.Controllers;
using backend.Reponsitories.ProductReponsitories;
using Microsoft.AspNetCore.Mvc;
using NashTechAssignment.backend_test;
using Xunit;

namespace backend_test.Controller.Test
{
    public class Get:IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Get(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public void GetAll_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;
            var BlobService = BlobServiceMock.BlobService();
            var mapper = MapperMock.Get();
            var productRepository = new ProductRepository(dbContext,BlobService,mapper);
            var productController = new ProductController(productRepository);
            // Act
            var result = productController.GetProducts();
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }
    }
}