using System.Threading.Tasks;
using LibraryShare.Product;
using Microsoft.AspNetCore.Mvc;
using backend.Reponsitories.ProductReponsitories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using backend.Models;
using backend.Constatnts;
using Microsoft.AspNetCore.Http;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private IProduct _productRepository;
        public ProductController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVM>> GetProduct(int Id)
        {
            var result = await _productRepository.GetProduct(Id);

            if (result is null) return NotFound("mdfk");

            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProducts()
        {
            var result = await _productRepository.GetProducts();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductVM>> RemoveProduct(int id)
        {
            var productRes = await _productRepository.DeleteProduct(id);
            return Ok(productRes);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVM>> CreateProduct([FromForm] ProductRequest productReq)
        {
            var product = await _productRepository.CreateProduct(productReq);

            return Created(Endpoints.Product, product);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ProductVM>> UpdateProduct(int id, [FromForm] ProductRequest productReq)
        {
            var productRes = await _productRepository.UpdateProduct(id, productReq);

            return Ok(productRes);
        }
    }

    public class ProductRequest
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}