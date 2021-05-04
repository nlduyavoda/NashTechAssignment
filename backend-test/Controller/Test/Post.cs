using System.Threading.Tasks;
using backend.Controllers;
using backend.Reponsitories.ProductReponsitories;
using backend_test.MockData;
using Microsoft.AspNetCore.Mvc;
using NashTechAssignment.backend_test;
using Xunit;

namespace backend_test.Controller.Test
{
    public class Post:IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Post(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }
        [Fact]
        public async Task Post_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;
            var mapper = MapperMock.Get();
            var fileService = BlobServiceMock.BlobService();
            var productToPost = NewData.CreateProduct();

            var productRepository = new ProductRepository(dbContext, fileService, mapper);
            var productController = new ProductController(productRepository);
            // Act
            var result = await productController.CreateProduct(productToPost);
            // Assert
            Assert.IsType<CreatedAtActionResult>(result.Result); 
        }
    }
}