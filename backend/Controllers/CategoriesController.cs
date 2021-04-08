using System.Threading.Tasks;
using LibraryShare.Product;
using Microsoft.AspNetCore.Mvc;
using backend.Reponsitories.ProductReponsitories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using LibraryShare.Categories;
using backend.Reponsitories.CategoryRepositories;

namespace backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class CategoriesController : ControllerBase
  {
    private ICategory _Category;
    public CategoriesController(ICategory Category)
    {
      _Category = Category;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriesVM>>> GetCategories()
    {
      var result = await _Category.GetCategories();
      return Ok(result);
    }
  }
}