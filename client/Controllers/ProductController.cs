using System;
using System.Threading.Tasks;
using client.services.HttpClientService;
using Microsoft.AspNetCore.Mvc;

namespace client.Controllers
{
  public class ProductController : Controller
  {
    private readonly IHttpClientServices _product;
    public ProductController(IHttpClientServices product)
    {
      _product = product;
    }

    public async Task<IActionResult> Index()
    {
      var product = await _product.GetProductById(1);
      return View(product);
    }

  }
}