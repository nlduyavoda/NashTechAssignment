using System.Threading.Tasks;
using LibraryShare.Product;
using Microsoft.AspNetCore.Mvc;
using backend.Reponsitories.ProductReponsitories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using LibraryShare.Categories;
using backend.Reponsitories.CategoryRepositories;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class CategoriesController : ControllerBase
    {
        private ICategory _CategoryRepository;
        public CategoriesController(ICategory CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriesVM>> GetCategory(int Id)
        {
            var result = await _CategoryRepository.GetCategory(Id);
            if (result is null) return NotFound("mdfk");
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriesVM>>> GetCategories()
        {
            var result = await _CategoryRepository.GetCategories();
            return Ok(result);
        }
    }
}