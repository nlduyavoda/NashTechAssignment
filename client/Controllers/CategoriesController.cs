using System.Threading.Tasks;
using client.services.HttpClientService;
using LibraryShare.Categories;
using Microsoft.AspNetCore.Mvc;

namespace client.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly IHttpClientServices _client;
    public CategoriesController(IHttpClientServices client)
    {
      _client = client;
    }
    [HttpGet("[controller]/{id}")]
    public async Task<ActionResult<CategoriesVM>> Index(int id)
    {
      var category = await _client.GetCategoriesById(id);
      return View(category);
    }

  }
}