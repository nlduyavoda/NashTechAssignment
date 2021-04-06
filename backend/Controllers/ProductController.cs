using System.Threading.Tasks;
using LibraryShare.Product;
using Microsoft.AspNetCore.Mvc;
using backend.Reponsitories.ProductReponsitories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
    public async Task<ActionResult<ProductVM>> GetProduct(double Id)
    {
      var result = await _productRepository.GetProduct(Id);
      return Ok(result);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductVM>>> GetProduct()
    {
      await Task.CompletedTask;
      var result = _productRepository.GetProducts();
      return Ok(result);
    }
  }
}