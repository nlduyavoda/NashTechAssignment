using System.Threading.Tasks;
using client.services.HttpClientService;
using Microsoft.AspNetCore.Mvc;

namespace client.ViewComponents
{
  public class CategoriesViewComponent : ViewComponent
  {
    private readonly IHttpClientServices _httpClient;

    public CategoriesViewComponent(IHttpClientServices httpClient)
    {
      _httpClient = httpClient;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
      var categories = await _httpClient.GetCategories();

      return View(categories);
    }
  }
}