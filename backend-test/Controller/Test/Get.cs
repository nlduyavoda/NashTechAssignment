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
            var mapper = MapperMock.Get();
            var BlobService = BlobServiceMock.Blobservice();

            var productsService = new ProductService(dbContext, BlobService, mapper);
            var productsController = new ProductsController(productsService);
            // Act
            var result = productsController.GetProducts();
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }
    }
}