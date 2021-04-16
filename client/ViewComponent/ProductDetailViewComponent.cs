using System.Threading.Tasks;
using client.services.HttpClientService;
using LibraryShare.Product;
using Microsoft.AspNetCore.Mvc;

namespace client.ViewComponents
{
  public class ProductDetailViewComponent : ViewComponent
  {
    private readonly IHttpClientServices _httpClient;

    public ProductDetailViewComponent(IHttpClientServices httpClient)
    {
      _httpClient = httpClient;
    }
    public async Task<IViewComponentResult> InvokeAsync(ProductVM product)
    {
      return await Task.FromResult(View("Detail", product));
    }
  }
}