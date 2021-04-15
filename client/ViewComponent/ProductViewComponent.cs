using System.Threading.Tasks;
using LibraryShare.Product;
using Microsoft.AspNetCore.Mvc;

namespace client.ViewComponents
{
  public class ProductViewComponent : ViewComponent
  {
    public async Task<IViewComponentResult> InvokeAsync(ProductVM product)
    {
      return await Task.FromResult(View("Default", product));
    }
  }
}